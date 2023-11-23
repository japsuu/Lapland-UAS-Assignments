using StatePattern.States;
using UnityEngine;

namespace StatePattern.Entities
{
    /// <summary>
    /// Simple enemy with state machine.
    /// Has 4 states: Idle, Chase, Attack, Flee.
    /// </summary>
    public class Enemy : DamageableEntity
    {
        [SerializeField] private float _attackDamage = 10f;
        [SerializeField] private float _attackCooldown = 1f;
        
        [Header("Movement")]
        [SerializeField] private float _movementSpeed = 4f;
        
        [Header("State machine")]
        [SerializeField] private float _chaseDistance = 7f;
        [SerializeField] private float _attackDistance = 2f;
        [SerializeField] private float _fleeHealth = 20f;
        
        private float _attackTimer;
        
        public static Enemy Singleton { get; private set; } // Singleton just for demonstration purposes. A real game would not have this.
        public StateMachine StateMachine { get; private set; }
        
        public float ChaseDistance => _chaseDistance;
        public float AttackDistance => _attackDistance;
        public float FleeHealth => _fleeHealth;
        public float MovementSpeed => _movementSpeed;


        public void TryAttack()
        {
            if (_attackTimer > 0f)
                return;
            
            if (Vector2.Distance(transform.position, Player.Singleton.transform.position) < AttackDistance)
                Player.Singleton.TakeDamage(_attackDamage);
            
            _attackTimer = _attackCooldown;
            Debug.Log("Enemy attacks!");
        }


        protected override void Awake()
        {
            if (Singleton == null)
                Singleton = this;
            else
                Destroy(gameObject);
            
            base.Awake();
            
            StateMachine = new StateMachine();
            StateMachine.ChangeState(new IdleState(this));
        }
        
        
        private void Update()
        {
            if (Player.Singleton == null)
                return;

            StateMachine.Update();
            _attackTimer -= Time.deltaTime;
        }
    }
}