using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using Assets.Scripts.Manager.Base;

namespace Assets.Scripts.Manager
{
    public class CanvasManager : SingletonBase<CanvasManager>
    {
        Sequence _fadeSequence;

        public GameObject _textPanel;
        public TMP_Text _narationText;
        public Image _fadeImg;

        public void FadeInOut()
        {
            if(_fadeSequence != null)
                _fadeSequence.Kill();

            _fadeSequence = DOTween.Sequence();
            _fadeSequence.Append(_fadeImg.DOFade(1f, 0.5f));
            _fadeSequence.Append(_fadeImg.DOFade(0f, 2f));
            _fadeSequence.Play();
        }
    }
}

