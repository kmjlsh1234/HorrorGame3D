using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager;

namespace Assets.Scripts.Object.FirstLobbyMap
{
    public class Basket : ObjectBase
    {
        [SerializeField] private bool _canPlace;
        public override void SetInteraction()
        {
            if(_canPlace)
            {

            }
        }
    }
}

