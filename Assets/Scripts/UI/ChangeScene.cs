using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static int currentScene = 1;

    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void SettingsChange()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Audio");
        //GamePause.Instance.PauseGame();
    }

    public void ReturnFromSettings()
    {
        SceneManager.LoadScene(currentScene);
        //GamePause.Instance.UnPause();

    }

    public void Quitgame()
    {
        Application.Quit();
        Debug.Log("Out of the game");
        //Enable this to reset level
        //PlayerPrefs.SetInt("levelReached", 1);
    }

    public void ToTheTilte()
    {
        SceneManager.LoadScene("Menu");
    }
}
