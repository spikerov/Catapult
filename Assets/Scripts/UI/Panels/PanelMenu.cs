using UnityEngine;

public class PanelMenu : Panel 
{
    [SerializeField] private PanelController _panelController;

    public void StartGame()
    {
        _panelController.OnGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}