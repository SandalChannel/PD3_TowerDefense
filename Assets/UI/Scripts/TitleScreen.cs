using Command;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace UI
{
    public class TowerDefenseTitleScreen : MonoBehaviour
    {
        private Button _startButton;
        private Button _quitButton;


        private void Start()
        {
            VisualElement rootElement = GetComponent<UIDocument>().rootVisualElement;

            _startButton = rootElement.Q<Button>("PlayButton");
            _startButton.RegisterCallback<ClickEvent>(StartGame);

            _quitButton = rootElement.Q<Button>("QuitToDesktopButton");
            _quitButton.RegisterCallback<ClickEvent>(Quit);
        }

        private void StartGame(ClickEvent clickEvent)
        {
            SceneManager.LoadScene("TowerDefense"); //load main game scene
        }

        private void Quit(ClickEvent clickEvent)
        {
            Application.Quit();
        }
    }
}
