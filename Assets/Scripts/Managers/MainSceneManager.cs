using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    [SerializeField]
    private Button _playButton;

    [SerializeField]
    private Button _exitButton;

    [SerializeField]
    private Button _creditsButton;


    private void Start()
    {
        _playButton.onClick.AddListener(OnPlayButtonClicked);
        _exitButton.onClick.AddListener(OnExitButtonClicked);
        _creditsButton.onClick.AddListener(OnCreditsButtonClicked);
    }

    private void OnExitButtonClicked()
    {
        GameManager.Instance.QuitGame();
    }

    private void OnPlayButtonClicked()
    {
        GameManager.Instance.LoadScene(SCENE.GAME);
    }

    private void OnCreditsButtonClicked()
    {
        GameManager.Instance.LoadScene(SCENE.CREDITS);
    }
}
