using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager;

namespace Assets.Scripts.Object
{
    public class HouseDoor : InteractableObject
    {
        [SerializeField] private Vector3 _nextPlayerPosition;
        [SerializeField] private string _nextMapName;

        public override void Event()
        {
            CanvasManager.Instance.FadeInOut();
            MapManager.Instance.LoadMapData(_nextMapName, _nextPlayerPosition);       
            Debug.Log("마녀의 집 안으로 들어가기");
        }
    }
}

