using UnityEngine.SceneManagement;

public class PanelGameOver : Panel
{
    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // рестарт игры
    }
}
