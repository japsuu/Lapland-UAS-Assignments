using UnityEngine;

namespace StatePattern.Entities
{
    public class Player : DamageableEntity
    {
        [SerializeField] private float _attackDamage = 10f;
        
        [SerializeField] private float _movementSpeed = 4f;
        
        private Vector2 _input;
        
        public static Player Singleton { get; private set; }


        protected override void Awake()
        {
            if (Singleton == null)
                Singleton = this;
            else
                Destroy(gameObject);
            
            base.Awake();
        }
        
        
        private void Update()
        {
            if (Enemy.Singleton == null)
                return;
            
            _input.x = Input.GetAxisRaw("Horizontal");
            _input.y = Input.GetAxisRaw("Vertical");
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Enemy.Singleton.TakeDamage(_attackDamage);
                Debug.Log("Player attacks!");
            }
        }
        
        
        private void FixedUpdate()
        {
            transform.Translate(_input * (_movementSpeed * Time.fixedDeltaTime));
        }
    }
}