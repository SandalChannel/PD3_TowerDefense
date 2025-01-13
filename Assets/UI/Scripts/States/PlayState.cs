using UnityEngine;
using StatePattern;
using UnityEditor;
using UnityEngine.UIElements;

namespace UI.States
{
    public class PlayState : IState
    {
        private readonly UIManager _manager;
        private readonly UIDocument _pauseScreen;
        
        public PlayState(UIManager UIManager, UIDocument pauseScreen)
        {
            _manager = UIManager;
            _pauseScreen = pauseScreen;

            _pauseScreen.enabled = false;
        }

        public void OnEnter()
        {
            _pauseScreen.enabled = false;
            Time.timeScale = 1f;
        }

        public void OnExit()
        {

        }

        public void Update()
        {
            if (Input.GetButtonDown("Cancel"))
            {
                _manager.StateMachine.MoveToState(_manager.PauseState);
            }
        }
    }
}
