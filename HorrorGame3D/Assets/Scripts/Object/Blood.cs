using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager;
using Assets.Scripts.Player;
using Assets.Scripts.Common;
using DG.Tweening;

namespace Assets.Scripts.Object
{
    public class Blood : MonoBehaviour
    {
        private bool _isEnter = false;

        [SerializeField] private Transform _leftWall;
        [SerializeField] private Transform _rightWall;

        Sequence seq;
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "Player" & !_isEnter)
            {
                _isEnter = true;
                MapManager.Instance._player.GetComponent<PlayerController>()._canMove = false;

                StartCoroutine(DeathCoroutine());
            }
        }

        IEnumerator DeathCoroutine()
        {
            if (seq != null)
                seq.Kill();

            seq = DOTween.Sequence();
            seq.Append(_leftWall.DOMoveX(0f, 1.5f));
            seq.Join(_rightWall.DOLocalMoveX(0f, 1.5f));
            seq.Play();
            SoundManager.Instance.PlaySound(SFXName.SFX_WallClose);
            yield return new WaitForSeconds(1f);
            SoundManager.Instance.PlaySound(SFXName.SFX_Crush);
            CanvasManager.Instance.DeathUIShow();


        }
    }
}

