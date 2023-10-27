using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager;
namespace Assets.Scripts.Object
{
    public class Cat : MonoBehaviour
    {
        private Transform _player;
        private void Awake()
        {
            _player = MapManager.Instance.FindPlayer().transform;
        }

        private void Update()
        {
            LookPlayer();
        }

        private void LookPlayer()
        {
            this.transform.LookAt(_player);
        }

        private void SaveData()
        {
            //데이터 저장 기능 구현
        }
    }
}

