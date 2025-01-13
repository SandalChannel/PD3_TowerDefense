using UnityEngine;
using StatePattern;
using UnityEditor;
using UnityEngine.UIElements;
using Command;
using UnityEngine.SceneManagement;

namespace UI.States
{
    public class PauseState : IState
    {
        private readonly UIManager _manager;
        private readonly UIDocument _pauseScreen;
        
        public PauseState(UIManager UIManager, UIDocument pauseScreen)
        {
            _manager = UIManager;
            _pauseScreen = pauseScreen;
        }

        public void OnEnter()
        {
            _pauseScreen.enabled = true;
            Time.timeScale = 0f;

            VisualElement rootElement = _pauseScreen.GetComponent<UIDocument>().rootVisualElement;

            Button continueButton = rootElement.Q<Button>("ContinueButton");
            continueButton.RegisterCallback<ClickEvent>(CloseMenu);

            Button newGameButton = rootElement.Q<Button>("NewGameButton");
            newGameButton.RegisterCallback<ClickEvent>(RestartScene);

            Button quitButton = rootElement.Q<Button>("QuitToMenuButton");
            quitButton.RegisterCallback<ClickEvent>(GoToTitle);

        }

        private void RestartScene(ClickEvent clickEvent)
        {
            CommandHistory.ClearCommandStack();

            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        private void GoToTitle(ClickEvent clickEvent)
        {
            _manager.StateMachine.MoveToState(_manager.TitleState);
        }

        private void CloseMenu(ClickEvent clickEvent) //closes menu and moves to the play state
        {
            _manager.StateMachine.MoveToState(_manager.PlayState);
        }

        public void OnExit()
        {

        }

        public void Update()
        {
            if (Input.GetButtonDown("Cancel"))
            {
                CloseMenu(null);
            }
        }
    }
}
