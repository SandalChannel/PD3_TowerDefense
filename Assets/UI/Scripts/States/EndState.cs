using UnityEngine;
using StatePattern;
using Command;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace UI.States
{
    public class EndState : IState
    {
        private readonly UIManager _manager;
        private readonly UIDocument _endScreen;

        public EndState(UIManager UIManager, UIDocument endScreen)
        {
            _manager = UIManager;
            _endScreen = endScreen;

            _endScreen.enabled = false;
        }

        public void OnEnter()
        {
            if (_endScreen != null)
            {
                _endScreen.enabled = true;
                Time.timeScale = 0f;

                VisualElement rootElement = _endScreen.GetComponent<UIDocument>().rootVisualElement;

                Button replayButton = rootElement.Q<Button>("ReplayButton");
                replayButton.RegisterCallback<ClickEvent>(StartReplay);

                Button newGameButton = rootElement.Q<Button>("NewGameButton");
                newGameButton.RegisterCallback<ClickEvent>(RestartScene);

                Button quitButton = rootElement.Q<Button>("QuitToMenuButton");
                quitButton.RegisterCallback<ClickEvent>(LoadTitle);
            }
        }

        private void RestartScene(ClickEvent clickEvent)
        {
            CommandHistory.ClearCommandStack();

            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        private void StartReplay(ClickEvent clickEvent)
        {
            _manager.StateMachine.MoveToState(_manager.ReplayState);
        }

        private void LoadTitle(ClickEvent clickEvent)
        {
            SceneManager.LoadScene("Title"); //load title scene
        }

        public void OnExit()
        {

        }

        public void Update()
        {

        }
    }
}
