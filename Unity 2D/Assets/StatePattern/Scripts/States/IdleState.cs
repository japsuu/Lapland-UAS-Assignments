using StatePattern.Entities;
using UnityEngine;

namespace StatePattern.States
{
    public class IdleState : StateMachine.IState
    {
        private readonly Enemy _enemy;
        
        
        public IdleState(Enemy enemy)
        {
            _enemy = enemy;
        }
        
        
        public void Enter()
        {
            Debug.Log("Entering Idle State");
        }
        
        
        public void Execute()
        {
            if (_enemy.Health <= _enemy.FleeHealth)
            {
                _enemy.StateMachine.ChangeState(new FleeState(_enemy));
                return;
            }

            float distanceToPlayer = Vector2.Distance(_enemy.transform.position, Player.Singleton.transform.position);
            
            if (distanceToPlayer > _enemy.ChaseDistance + 0.1f) // The +0.1f is to avoid constantly switching between two states.
            {
                _enemy.StateMachine.ChangeState(new ChaseState(_enemy));
                return;
            }
            
            if (distanceToPlayer < _enemy.AttackDistance)
                _enemy.StateMachine.ChangeState(new AttackState(_enemy));
        }
        
        
        public void Exit()
        {
            Debug.Log("Exiting Idle State");
        }
    }
}