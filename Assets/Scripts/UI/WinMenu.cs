using UnityEngine;

public class WinMenu : MonoBehaviour
{
    public void Start()
    {
        Time.timeScale = 0f; // Pause the game
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }

    public void OnRestartButtonClick()
    {
        Debug.Log("Restarting game...");
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}