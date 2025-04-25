using UnityEngine;
using UnityEngine.UI;

public class GameOverSceneManager : MonoBehaviour
{
    [SerializeField]
    private Button _playAgainButton;

    [SerializeField]
    private Button _mainMenuButton;


    private void Start()
    {
        _playAgainButton.onClick.AddListener(OnPlayAgainButtonClicked);
        _mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
    }

    private void OnMainMenuButtonClicked()
    {
        GameManager.Instance.LoadScene(SCENE.MAIN_MENU);
    }

    private void OnPlayAgainButtonClicked()
    {
        GameManager.Instance.LoadScene(SCENE.GAME);
    }
}
