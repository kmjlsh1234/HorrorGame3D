using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Assets.Scripts.Manager.Base;
using Assets.Scripts.Common;
using Assets.Scripts.Player;

namespace Assets.Scripts.Manager
{
    public class MapManager : SingletonBase<MapManager>
    {
        private ObjectPooler _objectPooler;
        [SerializeField] private GameObject _currentMap;
        
        [SerializeField] private Vector3 _newGamePlayerPosition;
        public GameObject _player;

        
        protected override void Awake()
        {
            base.Awake();
            _player = FindPlayer();
            
        }

        private void Start()
        {
            LoadMapData("StartMap", _newGamePlayerPosition);
        }

        public void LoadMapData(string _mapName, Vector3 _playerPosition)
        {
            _player.GetComponent<CapsuleCollider>().enabled = false;
            _player.GetComponent<PlayerController>().enabled = false;

            CanvasManager.Instance.FadeInOut();

            if (_currentMap != null)
                _currentMap.SetActive(false);

            GameObject _nextMap = _objectPooler.GetMapObject(_mapName);

            _currentMap = _nextMap;
            _currentMap.SetActive(true);
            
            _player.transform.position = _playerPosition;
            _player.GetComponent<CapsuleCollider>().enabled = true;
            _player.GetComponent<PlayerController>().enabled = true;
        }

        public string GetMapName()
        {
            return _currentMap.name;
        }

        public void SetMapObjectPool(ObjectPooler pool)
        {
            _objectPooler = pool;
        }

        public GameObject FindPlayer()
        {
            GameObject target = GameObject.FindWithTag("Player");
            return target;
        }
    }
}