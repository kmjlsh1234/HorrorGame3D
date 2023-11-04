using Assets.Scripts.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Assets.Scripts.Common
{
    public class ObjectPooler : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _mapPoolList = new List<GameObject>();

        private void Awake()
        {
            _mapPoolList.Clear();
            MapManager.Instance.SetMapObjectPool(this);
            
        }
        public GameObject GetMapObject(string name)
        {
            GameObject go = _mapPoolList.FirstOrDefault(x => x.name == name);

            if (go != null)
                return go;

            else
            {
                var _filePath = $"Pref/Map/{name}";
                GameObject _newObj = Resources.Load<GameObject>(_filePath);
                GameObject _map = Instantiate(_newObj, Vector3.zero, Quaternion.identity, transform);
                _map.name = _map.name.Replace("(Clone)", "");
                _mapPoolList.Add(_map);
                return _map;
            }
        }
    }
}

