using UnityEngine;
using StatePattern;
using Logic.Game;
using UnityEngine.SceneManagement;

namespace UI.States
{
    public class ReplayState : IState
    {
        private readonly UIManager _manager;
        
        public ReplayState(UIManager UIManager)
        {
            _manager = UIManager;
        }

        public void OnEnter()
        {
            GameLogic.GameTime = 0f;
            GameLogic.IsReplaying = true;
            Time.timeScale = 1f;

            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
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
