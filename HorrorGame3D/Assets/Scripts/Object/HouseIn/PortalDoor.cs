using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Common;
using Assets.Scripts.Manager;
using Assets.Scripts.Map;

namespace Assets.Scripts.Object
{
    public class PortalDoor : ObjectBase
    {
        private Animator _anim;
        private bool _isOpen;
        [SerializeField] private HouseIn _houseIn;

        [SerializeField] private string _nextMapName;
        [SerializeField] private Vector3 _nextPlayerPosition;
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
        }

        public void OpenDoor()
        {
            _isOpen = true;
            _anim.SetTrigger("DoorOpen");
            _houseIn.PortalDoorEnter();
            _playerController.FinishInteraction();
            SoundManager.Instance.PlaySound(SFXName.SFX_Door);
            MapManager.Instance.LoadMapData(_nextMapName, _nextPlayerPosition);
        }

        

        public void SetMapScript(HouseIn _mapScript)
        {
            _houseIn = _mapScript;
        }
    }

}

