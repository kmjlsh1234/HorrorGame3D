using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager;
namespace Assets.Scripts.Map
{
    public class MapBase : MonoBehaviour
    {
        public GameObject _player;

        protected virtual void Awake()
        {
            _player = MapManager.Instance.gameObject;
        }
    }
}

