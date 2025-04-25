using System.Collections;
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

    [SerializeField]
    public Animator transitionAnim;

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
        StartCoroutine(LoadSceneCoroutine(sCENE));
    }

    private IEnumerator LoadSceneCoroutine(SCENE sCENE)
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene((int)sCENE);
        transitionAnim.SetTrigger("Start");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
