using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("Test");
    }

    public void SettingsMenu()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
