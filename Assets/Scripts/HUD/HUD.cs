using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private Scrollbar _energyBar;

    [SerializeField]
    private Scrollbar _healthbar;

    [SerializeField]
    private Button _mainMenu;

    [SerializeField]
    private GameObject _controlMenu;

    [SerializeField]
    private Button _controlButton;

    [SerializeField]
    private Button _backControlButton;

    [SerializeField] 
    private Life _playerLife;

    [SerializeField]
    private TMPro.TextMeshProUGUI _crystalCounterText;

    private int _numOfCrystals = 0;

    private void Update()
    {
        UpdateHealthBar((_playerLife._currentLife / _playerLife._maxLife));
    }

    private void OnEnable()
    {
        PlayerActions.OnPlayerEnergyChanged += UpdateEnergyBar;
        PlayerActions.OnPlayerTouchCrystal += UpdateCrystalCounter;
    }



    private void OnDisable()
    {
        PlayerActions.OnPlayerEnergyChanged -= UpdateEnergyBar;
        PlayerActions.OnPlayerTouchCrystal -= UpdateCrystalCounter;
    }

    private void Start()
    {
        _energyBar.size = 1.0f;
        _healthbar.size = 1.0f;
        _crystalCounterText.text = "0";
        _mainMenu.onClick.AddListener(OnMainMenuClick);
        _controlButton.onClick.AddListener(OnControlButtonClick);
        _backControlButton.onClick.AddListener(OnBackControlButtonClick);
    }

    private void OnControlButtonClick()
    {
        _controlMenu.SetActive(true);
    }

    private void OnBackControlButtonClick()
    {
        _controlMenu.SetActive(false);
    }

    private void OnMainMenuClick()
    {
        LevelSceneManager.instance.LoadScene("MainMenu");
    }

    private void UpdateEnergyBar(float value)
    {
        _energyBar.size = value;
    }

    private void UpdateCrystalCounter()
    {
        _numOfCrystals++;
        _crystalCounterText.text = _numOfCrystals.ToString();
    }

    private void UpdateHealthBar(float value)
    {
        _healthbar.size = value;
    }
}
