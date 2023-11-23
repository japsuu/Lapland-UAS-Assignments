using StatePattern.Entities;
using UnityEngine;

namespace StatePattern.States
{
    public class AttackState : StateMachine.IState
    {
        private readonly Enemy _enemy;
        
        
        public AttackState(Enemy enemy)
        {
            _enemy = enemy;
        }
        
        
        public void Enter()
        {
            Debug.Log("Entering Attack State");
        }
        
        
        public void Execute()
        {
            if (_enemy.Health <= _enemy.FleeHealth)
            {
                _enemy.StateMachine.ChangeState(new FleeState(_enemy));
                return;
            }
            
            float distanceToPlayer = Vector2.Distance(_enemy.transform.position, Player.Singleton.transform.position);
            
            if (distanceToPlayer > _enemy.AttackDistance)
            {
                _enemy.StateMachine.ChangeState(new IdleState(_enemy));
                return;
            }
            
            _enemy.TryAttack();
        }
        
        
        public void Exit()
        {
            Debug.Log("Exiting Attack State");
        }
    }
}