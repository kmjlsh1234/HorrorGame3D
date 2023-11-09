using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager;
using Assets.Scripts.Map;

namespace Assets.Scripts.Object
{
    public class Paper : InteractableObject
    {
        [SerializeField] private HouseIn _houseIn;

        public void SetMapScript(HouseIn _mapScript)
        {
            _houseIn = _mapScript;
        }

        public override void Event()
        {
            _houseIn.DoorEvent();
        }
    }
}

