using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SCENE : int
{
    MAIN_MENU = 0,
    GAME = 4,

    GAME_OVER = 2,
    GAME_WIN = 99,
    CREDITS = 3,
    SETTINGS = 98
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(SCENE sCENE)
    {
        SceneManager.LoadScene((int)sCENE);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
