using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager;

namespace Assets.Scripts.Object
{
    public class InteractableObject : ObjectBase
    {
        [SerializeField] protected string[] _narationList;
        protected int _naCount = 0;

        public override void SetInteraction()
        {
            if (_naCount == 0)
            {
                _playerController.StartInteraction();
                CanvasManager.Instance.TextPanelShow();
            }
                

            else if (_naCount == _narationList.Length)
            {
                if (_playerController == null)
                    Debug.Log("Player Controller Not Found!!");
                
                _playerController.FinishInteraction();
                CanvasManager.Instance.TextPanelClose();
                _playerController.FinishInteraction();
                _naCount = 0;
                Event();
                return;
            }

            CanvasManager.Instance._narationText.text = _narationList[_naCount];
            _naCount++;
        }

        public virtual void Event() { }
    }
}

