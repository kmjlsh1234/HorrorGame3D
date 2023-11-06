using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashManager : MonoBehaviour
{
    [SerializeField] private Button _newButton;
    [SerializeField] private Button _loadButton;
    [SerializeField] private Button _quitButton;

    private void Awake()
    {
        AddEvent();
    }

    private void AddEvent()
    {
        _newButton.onClick.AddListener(() => SceneManager.LoadScene("MainScene"));
        _loadButton.onClick.AddListener(() => SceneManager.LoadScene("MainScene"));
        _quitButton.onClick.AddListener(() => Application.Quit());
    }
}
