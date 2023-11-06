using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager;
using Assets.Scripts.Common;

namespace Assets.Scripts.Map
{
    public class MapBase : MonoBehaviour
    {
        public GameObject _player;
        public MapType _mapType;
        protected virtual void Awake()
        {
            _player = MapManager.Instance.gameObject;
        }

        private void OnEnable()
        {
            SoundManager.Instance.CheckBGMChange(_mapType);
        }
    }
}

