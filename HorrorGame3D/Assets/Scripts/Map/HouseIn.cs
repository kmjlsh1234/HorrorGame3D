using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Object;
using Assets.Scripts.Manager;
namespace Assets.Scripts.Map
{
    public class HouseIn : MapBase
    {
        [Header("Transform Element")]
        [SerializeField] private Transform _doorTrans;

        [Header("GameObject Element")]
        [SerializeField] private Door _door;
        [SerializeField] private GameObject _hideWall;
        [SerializeField] private Paper _paper;
        [SerializeField] private PortalDoor _portalDoor;

        protected override void Awake()
        {
            base.Awake();
            Init();
        }

        private void Init()
        {
            _player = GameObject.FindWithTag("Player");
            _paper.SetMapScript(this);
            _portalDoor.SetMapScript(this);
        }

        public void DoorEvent()
        {
            _door.CloseDoor();
            _door.gameObject.SetActive(false);
            _portalDoor.gameObject.SetActive(true);
        }

        public void PortalDoorEnter()
        {
            _hideWall.SetActive(true);
            CanvasManager.Instance.FadeInOut();
            //MapManager.Instance.LoadMapData();
        }

    }
}

