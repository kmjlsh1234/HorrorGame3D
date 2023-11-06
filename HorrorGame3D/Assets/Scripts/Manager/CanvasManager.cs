using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using Assets.Scripts.Manager.Base;
using Assets.Scripts.Object;
using Assets.Scripts.Player;

namespace Assets.Scripts.Manager
{
    public class CanvasManager : SingletonBase<CanvasManager>
    {
        public GameObject _textPanel;
        public TMP_Text _narationText;
        public Image _fadeImg;

        public GameObject _deathPanel;
        public ChoosePanel _choosePanel;

        public PlayerController _playerController;

        protected override void Awake()
        {
            base.Awake();
            _playerController = GameObject.FindAnyObjectByType<PlayerController>();
        }

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
        public void DeathUIShow()
        {
            _deathPanel.SetActive(true);
        }

        public void ChoosePanelShow(List<string> _stringList, ObjectBase _baseScript)
        {
          
            _choosePanel.gameObject.SetActive(true);
            _choosePanel.SetData(_stringList, _baseScript);
            _playerController.enabled = false;
        }
    }
}

