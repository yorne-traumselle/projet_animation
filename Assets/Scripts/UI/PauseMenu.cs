using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    Scrollbar volumeScroll;

    [SerializeField]
    Scrollbar healthbarSizeScroll;
    
    public void Start()
    {
        Time.timeScale = 0f; // Pause the game
        volumeScroll.value = AudioManager.GetMusicVolume();
        volumeScroll.onValueChanged.AddListener(SetVolume);
        healthbarSizeScroll.value = HealthbarSizeManager.getValue();
        healthbarSizeScroll.onValueChanged.AddListener(HealthbarSizeManager.setSize);
    }

    public void SetVolume(float volume)
    {
        // Debug.Log("Volume set to: " + volume);
        AudioManager.SetMusicVolume(volume);
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