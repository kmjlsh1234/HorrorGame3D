using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Common;
using Assets.Scripts.Manager;

namespace Assets.Scripts.Object
{
    public class Door : ObjectBase
    {
        private Animator _anim;
        private bool _isOpen;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
        }

        public void SetData()
        {

        }

        public override void SetInteraction()
        {
            

            if (!_isOpen)
                OpenDoor();
            else
                CloseDoor();


        }

        public void OpenDoor()
        {
            _isOpen = true;
            _anim.SetTrigger("DoorOpen");
            SoundManager.Instance.PlaySound(SFXName.SFX_Door);
        }

        public void CloseDoor()
        {
            _isOpen = false;
            _anim.SetTrigger("DoorClose");
            SoundManager.Instance.PlaySound(SFXName.SFX_Door);
        }
    }
}

