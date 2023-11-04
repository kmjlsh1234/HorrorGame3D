using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Object;
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

        protected override void Awake()
        {
            base.Awake();
            Init();
        }

        private void Init()
        {
            _player = GameObject.FindWithTag("Player");
            _paper.SetMapScript(this);
        }

        public void DoorEvent()
        {
            _door.CloseDoor();
        }


    }
}

