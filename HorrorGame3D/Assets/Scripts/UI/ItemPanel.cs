using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts.UI
{
    public class ItemPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _itemSlot;
        [SerializeField] private GameObject _chooseButtonFolder;
        [SerializeField] private Button _yesBtn;
        [SerializeField] private Button _noBtn;
        [SerializeField] private TMP_Text _yesText;
        [SerializeField] private TMP_Text _noText;

        // Start is called before the first frame update
        private void Awake()
        {
            AddEvent();
        }

        private void AddEvent()
        {
            // _yesBtn.onClick.AddListener(()_ => );
            // _noBtn.onClick.AddListener(()_ => );
        }

        public void SetData(string[] list)
        {
            _yesText.text = list[0];
            _noText.text = list[1];
        }

        public void AddSlot()
        {

        }
    }
}

