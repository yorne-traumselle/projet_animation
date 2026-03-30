using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Retourne au menu");
    }
}
