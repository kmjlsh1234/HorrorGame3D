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
        [SerializeField] private bool _canOpen;
        private void Awake()
        {
            _anim = this.transform.parent.GetComponent<Animator>();
        }

        public void SetData()
        {

        }

        public override void SetInteraction()
        {
            if(!_canOpen)
            {
                Debug.Log("못 여는 문");
            }
            else
            {
                if (!_isOpen)
                    OpenDoor();
                else
                    CloseDoor();
            }
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

