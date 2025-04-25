using UnityEngine;
using UnityEngine.UI;

public class CreditsSceneManager : MonoBehaviour
{
    [SerializeField]
    private Button _backButton;

    private void Start()
    {
        _backButton.onClick.AddListener(OnBackButtonClicked);
    }

    private void OnBackButtonClicked()
    {
        GameManager.Instance.LoadScene(SCENE.MAIN_MENU);
    }
}
