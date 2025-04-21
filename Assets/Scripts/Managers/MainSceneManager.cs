using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    [SerializeField]
    private Button _playButton;

    [SerializeField]
    private Button _exitButton;


    private void Start()
    {
        _playButton.onClick.AddListener(OnPlayButtonClicked);
        _exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    private void OnExitButtonClicked()
    {
        GameManager.Instance.QuitGame();
    }

    private void OnPlayButtonClicked()
    {
        GameManager.Instance.LoadScene(SCENE.GAME);
    }
}
