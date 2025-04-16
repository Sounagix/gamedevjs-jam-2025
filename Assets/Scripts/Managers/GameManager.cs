using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SCENE : int
{
    MAIN_MENU = 0,
    GAME = 1,
    GAME_OVER = 2,
    GAME_WIN = 3,
    SETTINGS = 4,
    CREDITS = 5
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
}
