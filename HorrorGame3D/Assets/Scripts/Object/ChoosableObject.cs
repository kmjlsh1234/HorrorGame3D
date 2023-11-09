using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager;
namespace Assets.Scripts.Object
{
    public class ChoosableObject : ObjectBase
    {
        [SerializeField] private string[] _chooseList;
        public override void SetInteraction()
        {
            _playerController.StartInteraction();
            CanvasManager.Instance.ChoosePanelShow(_chooseList, this);
        }
    }
}

