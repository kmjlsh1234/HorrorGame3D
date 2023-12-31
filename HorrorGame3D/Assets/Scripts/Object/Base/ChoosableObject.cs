using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager;
namespace Assets.Scripts.Object
{
    public class ChoosableObject : ObjectBase
    {
        [SerializeField] private string[] _chooseList = new string[3];
        public override void SetInteraction()
        {
            _playerController.StartInteraction();
            CanvasManager.Instance.ChoosePanelShow(_chooseList, this);
        }

        public virtual void ChooseButton()
        {
            _playerController.FinishInteraction();
            CanvasManager.Instance.ChoosePanelClose();
        }
    }
}

