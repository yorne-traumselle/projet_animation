using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void Start()
    {
        Time.timeScale = 0f; // Pause the game
    }
    
    public void OnResumeButtonClick()
    {
        Time.timeScale = 1f; // Resume the game
        Destroy(gameObject);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}