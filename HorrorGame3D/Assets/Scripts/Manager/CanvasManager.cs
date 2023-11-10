using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using Assets.Scripts.Manager.Base;
using Assets.Scripts.Object;
using Assets.Scripts.Player;
using Assets.Scripts.UI;

namespace Assets.Scripts.Manager
{
    public class CanvasManager : SingletonBase<CanvasManager>
    {
        public GameObject _textPanel;
        public TMP_Text _narationText;
        public Image _fadeImg;

        public GameObject _deathPanel;
        public ChoosePanel _choosePanel;
        public ItemPanel _itemPanel;
        public PlayerController _playerController;

       
        protected override void Awake()
        {
            base.Awake();
            _playerController = GameObject.FindAnyObjectByType<PlayerController>();
        }

        #region :::: TextPanelUI
        public void TextPanelShow()
        {
            _textPanel.SetActive(true);
        }

        public void TextPanelClose()
        {
            _textPanel.SetActive(false);
        }
        #endregion

        #region :::: ChoosePanelUI
        public void ChoosePanelShow(string[] _stringList, ChoosableObject _baseScript)
        {

            _choosePanel.gameObject.SetActive(true);
            _choosePanel.SetData(_stringList, _baseScript);
        }

        public void ChoosePanelClose()
        {
            _choosePanel.gameObject.SetActive(false);
        }
        #endregion

        #region :::: FadeInOutUI
        public void FadeInOut()
        {
            StartCoroutine(FadeCoroutine());
        }
        
        IEnumerator FadeCoroutine()
        {
            _fadeImg.DOFade(1f, 0.25f);
            yield return new WaitForSeconds(1.5f);
            _fadeImg.DOFade(0f, 2f);
            yield return new WaitForSeconds(2f);
        }
        #endregion

        #region :::: DeathUI
        public void DeathUIShow()
        {
            _deathPanel.SetActive(true);
        }
        #endregion

        #region :::: ItemPanelUI
        public void ItemPanelShow()
        {
            _itemPanel.gameObject.SetActive(true);
        }

        public void ItemPanelClose()
        {
            _itemPanel.gameObject.SetActive(false);
        }

        public void AddItem(string itemName)
        {
            _itemPanel.AddSlot(itemName);
        }

        public void RemoveItem(string itemName)
        {
            _itemPanel.RemoveSlot(itemName);
        }
        #endregion

        #region :::: SavePanelUI
        public void SavePanelShow()
        {

        }

        public void SavePanelClose()
        {

        }
        #endregion

    }
}

