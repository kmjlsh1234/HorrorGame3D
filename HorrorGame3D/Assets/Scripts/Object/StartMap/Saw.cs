using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager;

namespace Assets.Scripts.Object.StartMap
{
    public class Saw : ChoosableObject
    {
        private const string ItemName = "Saw";
        public override void ChooseButton()
        {
            base.ChooseButton();
            Debug.Log("≈È »πµÊ!");
            GameManager.Instance.AddItem(ItemName);
        }
    }
}

