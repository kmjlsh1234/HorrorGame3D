using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Common;
using Assets.Scripts.Manager;
namespace Assets.Scripts.Object
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private Vector3 _nextPlayerPosition;
        public PortalType _portalType;
        private bool _isEnter = false;
        private void OnEnable()
        {
            _isEnter = false;
        }
        public void OnTriggerEnter(Collider collision)
        {
            
            if(collision.gameObject.name == "Player" & !_isEnter)
            {
                Debug.Log(_portalType.ToString() + " Æ÷Å» µé¾î¿È");
                _isEnter = true;
                var _nextMap = _portalType.ToString();
                string[] _stringList = _nextMap.Split("_");
                
                MapManager.Instance.LoadMapData(_stringList[2], _nextPlayerPosition);

            }
        }       
    }
}

