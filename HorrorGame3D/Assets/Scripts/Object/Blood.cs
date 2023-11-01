using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager;
using Assets.Scripts.Player;
namespace Assets.Scripts.Object
{
    public class Blood : MonoBehaviour
    {
        private bool _isEnter = false;

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "Player" & !_isEnter)
            {
                _isEnter = true;
                MapManager.Instance._player.GetComponent<PlayerController>().enabled = false;
                Debug.Log("Player»ç¸Á");
            }
        }
    }
}

