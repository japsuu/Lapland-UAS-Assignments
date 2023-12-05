using StatePattern.Entities;
using UnityEngine;

namespace StatePattern.States
{
    public class ChaseState : StateMachine.IState
    {
        private readonly Enemy _enemy;
        
        
        public ChaseState(Enemy enemy)
        {
            _enemy = enemy;
        }
        
        
        public void Enter()
        {
            Debug.Log("Entering Chase State");
        }
        
        
        public void Execute()
        {
            if (_enemy.Health <= _enemy.FleeHealth)
            {
                _enemy.StateMachine.ChangeState(new FleeState(_enemy));
                return;
            }

            float distanceToPlayer = Vector2.Distance(_enemy.transform.position, Player.Singleton.transform.position);
            
            if (distanceToPlayer < _enemy.ChaseDistance - 0.1f) // The -0.1f is to avoid constantly switching between two states.
            {
                _enemy.StateMachine.ChangeState(new IdleState(_enemy));
                return;
            }
            
            _enemy.transform.position = Vector2.MoveTowards(_enemy.transform.position, Player.Singleton.transform.position, _enemy.MovementSpeed * Time.deltaTime);
        }
        
        
        public void Exit()
        {
            Debug.Log("Exiting Chase State");
        }
    }
}