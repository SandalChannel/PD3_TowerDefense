using StatePattern;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TitleState : IState
{
    private readonly UIManager _manager;
    private readonly UIDocument _pauseScreen;

    public TitleState(UIManager UIManager, UIDocument pauseScreen)
    {
        _manager = UIManager;
        _pauseScreen = pauseScreen;
    }


    public void OnEnter()
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
