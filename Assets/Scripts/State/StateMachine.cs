using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class StateMachine
    {
        private IState _currentState;
        public StateMachine(IState startState)
        {
            if (startState == null)
            {
                throw new InvalidOperationException("Startstate cannot be null");
            }
            
            _currentState = startState;
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
