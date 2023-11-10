using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;
using Assets.Scripts.Object;
using Assets.Scripts.Manager;

public class ChoosePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _infoText;
    [SerializeField] private TMP_Text _yesText;
    [SerializeField] private TMP_Text _noText;

    private ChoosableObject _chooseableObject;

    private void Awake()
    {
        AddEvent();
    }
    private void AddEvent()
    {
        Button _yesButton = _yesText.GetComponent<Button>();
        Button _noButton = _noText.GetComponent<Button>();
        _yesButton.OnClickAsObservable().Subscribe(_ => OnClickYesButton()).AddTo(gameObject);
        _noButton.OnClickAsObservable().Subscribe(_ => OnClickNoButton()).AddTo(gameObject);
    }

    public void SetData(string[] _list, ChoosableObject _baseScript)
    {
        _infoText.text = _list[0];
        _yesText.text = _list[1];
        _noText.text = _list[2];
        _chooseableObject = _baseScript;
    }

    private void OnClickYesButton()
    {
        gameObject.SetActive(false);
        _chooseableObject.ChooseButton();
    }

    private void OnClickNoButton()
    {
        CanvasManager.Instance._playerController.enabled = true;
        gameObject.SetActive(false);
        
    }
    
}
