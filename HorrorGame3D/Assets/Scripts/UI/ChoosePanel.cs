using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.Object;
using Assets.Scripts.Manager;

public class ChoosePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _infoText;
    [SerializeField] private TMP_Text _yesText;
    [SerializeField] private TMP_Text _noText;

    private ObjectBase _objectBase;

    private void Awake()
    {
        AddEvent();
    }
    private void AddEvent()
    {
        _yesText.GetComponent<Button>().onClick.AddListener(() => OnClickYesButton());
        _noText.GetComponent<Button>().onClick.AddListener(() => OnClickYesButton());
    }

    public void SetData(List<string> _list, ObjectBase _baseScript)
    {
        _infoText.text = _list[0];
        _yesText.text = _list[1];
        _noText.text = _list[2];
        _objectBase = _baseScript;
    }

    private void OnClickYesButton()
    {
        gameObject.SetActive(false);
        _objectBase.ChooseButton();
    }

    private void OnClickNoButton()
    {
        CanvasManager.Instance._playerController.enabled = true;
        gameObject.SetActive(false);
        
    }
    
}
