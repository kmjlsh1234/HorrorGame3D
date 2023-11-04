using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        public override void SetInteraction()
        {
            if(!_isOpen)
            {
                _isOpen = true;
                _anim.SetTrigger("DoorOpen");
            }
                
        }
    }
}

