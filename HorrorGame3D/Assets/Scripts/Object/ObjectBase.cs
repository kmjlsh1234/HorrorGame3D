using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Player;
namespace Assets.Scripts.Object
{
    public class ObjectBase : MonoBehaviour
    {
        protected PlayerController _playerController;

        public virtual void SetPlayerController(PlayerController controller)
        {
            _playerController = controller;
        }

        public virtual void SetInteraction()
        {

        }

        public virtual void ChooseButton()
        {
            _playerController.FinishInteraction();
        }
    }
}

