using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public static GamePause Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        // if (isGamePaused == true)
        // {
        //     Time.timeScale = 0f; // pause the game
        // }
        // else
        // {
        //     Time.timeScale = 1f; // unpause the game
        // }
    }
    public void UnPause()
    {
        Time.timeScale = 1f;
        // if (isGamePaused == true)
        // {
        //     Time.timeScale = 0f; // pause the game
        // }
        // else
        // {
        //     Time.timeScale = 1f; // unpause the game
        // }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
