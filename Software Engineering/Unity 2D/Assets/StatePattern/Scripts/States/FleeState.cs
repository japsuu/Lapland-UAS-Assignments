using StatePattern.Entities;
using UnityEngine;

namespace StatePattern.States
{
    public class FleeState : StateMachine.IState
    {
        private readonly Enemy _enemy;
        
        
        public FleeState(Enemy enemy)
        {
            _enemy = enemy;
        }
        
        
        public void Enter()
        {
            Debug.Log("Entering Flee State");
        }
        
        
        public void Execute()
        {
            if (_enemy.Health > _enemy.FleeHealth)  // NOTE: This will not happen, because in this example enemies cannot heal.
                _enemy.StateMachine.ChangeState(new ChaseState(_enemy));
            else
                _enemy.transform.position = Vector2.MoveTowards(_enemy.transform.position, Player.Singleton.transform.position, -_enemy.MovementSpeed * Time.deltaTime);
        }
        
        
        public void Exit()
        {
            Debug.Log("Exiting Flee State");
        }
    }
}