using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager;
using Assets.Scripts.Common;
namespace Assets.Scripts.Object.FirstLobbyMap
{
    public class EventPresent : ObjectBase
    {
        [SerializeField] private List<string> _chooseStringList = new List<string>();
        [SerializeField] private GameObject _teddyBear;
        [SerializeField] private Animator _anim;

        private void Awake()
        {
            _anim = this.transform.parent.GetComponent<Animator>();
        }
        public override void SetInteraction()
        {
            CanvasManager.Instance.ChoosePanelShow(_chooseStringList, this);
              

        }

        public override void ChooseButton()
        {
            Debug.Log("∞ıµπ¿Ã »πµÊ!");
            _teddyBear.SetActive(false);
            _anim.SetTrigger("PresentDrop");
            SoundManager.Instance.PlaySound(SFXName.SFX_Crush);
        }
    }
}

