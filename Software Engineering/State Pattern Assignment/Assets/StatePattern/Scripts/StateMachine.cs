namespace StatePattern
{
    public class StateMachine
    {
        public interface IState
        {
            public void Enter();
            public void Execute();
            public void Exit();
        }

        private IState _currentState;
        
        
        public void ChangeState(IState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
        
        
        public void Update()
        {
            _currentState.Execute();
        }
    }
}