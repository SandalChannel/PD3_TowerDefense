using System;

namespace StatePattern
{
    public class StateMachine
    {
        private IState _currentState;
        public StateMachine(IState startState)
        {
            _currentState = startState ?? throw new InvalidOperationException("Startstate cannot be null");
            _currentState?.OnEnter();
        }

        public void Update()
        {
            _currentState.Update();
        }

        public void MoveToState(IState nextState)
        {
            if (nextState != null)
            {
                _currentState.OnExit();
                _currentState = nextState;
                _currentState.OnEnter();
            }
        }
    }
}
