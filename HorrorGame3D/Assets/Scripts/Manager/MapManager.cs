using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Assets.Scripts.Manager.Base;
using Assets.Scripts.Player;

namespace Assets.Scripts.Manager
{
    public class MapManager : SingletonBase<MapManager>
    {
        [SerializeField] private GameObject _currentMap;

        [SerializeField] private Vector3 _newGamePlayerPosition;
        public GameObject _player;

        
        protected override void Awake()
        {
            base.Awake();
            _player = FindPlayer();
            LoadMapData("StartMap", _newGamePlayerPosition); 
        }

        public void LoadMapData(string _mapName, Vector3 _playerPosition)
        {
            _player.GetComponent<CapsuleCollider>().enabled = false;
            _player.GetComponent<PlayerController>().enabled = false;

            CanvasManager.Instance.FadeInOut();

            if(_currentMap != null)
                Destroy(_currentMap);
            
            string _mapPath = $"Pref/Map/{_mapName}";
            GameObject _nextMap = Resources.Load<GameObject>(_mapPath);
            GameObject _createMap = Instantiate(_nextMap, Vector3.zero, Quaternion.identity);
            _currentMap = _createMap;
            _createMap.transform.position = Vector3.zero;
            _player.transform.position = _playerPosition;

            _player.GetComponent<CapsuleCollider>().enabled = true;
            _player.GetComponent<PlayerController>().enabled = true;
        }

        public GameObject FindPlayer()
        {
            GameObject target = GameObject.FindWithTag("Player");
            return target;
        }
    }
}

