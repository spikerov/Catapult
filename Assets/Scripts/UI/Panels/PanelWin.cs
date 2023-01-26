using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelWin : Panel
{
    public void GoMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // рестарт игры
    }
}
