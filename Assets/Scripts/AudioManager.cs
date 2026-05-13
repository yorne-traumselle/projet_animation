using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    static float musicVolume = 1f;
    [SerializeField] AudioSource musicSource;

    public static void SetMusicVolume(float volume)
    {   
        musicVolume = Mathf.Clamp01(volume);
        AudioListener.volume = musicVolume;
    }

    public static float GetMusicVolume()
    {
        return musicVolume;
    }
}