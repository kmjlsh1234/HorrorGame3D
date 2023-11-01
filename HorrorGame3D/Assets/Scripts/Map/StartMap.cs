using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Map
{
    public class StartMap : MapBase
    {
        [Header("Transform Element")]
        [SerializeField] private Transform _playerTrans;
        [SerializeField] private Transform _catTrans;
        [SerializeField] private Transform _sawTrans;

        [Header("Prefab Element")]
        [SerializeField] private GameObject _cat;
        [SerializeField] private GameObject _saw;

        protected override void Awake()
        {
            base.Awake();
            Init();
        }

        private void Init()
        {
            _player = GameObject.FindWithTag("Player");
            _player.transform.position = _playerTrans.position;
            SpawnObject(_saw, _sawTrans);
            SpawnObject(_cat, _catTrans);
        }

        private void SpawnObject(GameObject _obj, Transform _trans)
        {
            GameObject go = Instantiate(_obj, _trans);
        }
    }
}

