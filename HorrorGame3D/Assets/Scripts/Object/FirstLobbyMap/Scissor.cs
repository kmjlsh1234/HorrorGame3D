using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager;
namespace Assets.Scripts.Object.FirstLobbyMap
{
    public class Scissor : ObjectBase
    {
        private bool _canCut;
        [SerializeField] private string[] _narationList;
        int i = 0;

        public override void SetInteraction()
        {
            if(!_canCut)
            {
                Debug.Log("못자름");
                if (i == 0)
                {
                    CanvasManager.Instance._textPanel.SetActive(true);

                }
                else if (i == _narationList.Length)
                {
                    CanvasManager.Instance._textPanel.SetActive(false);
                    i = 0;
                    return;
                }
                CanvasManager.Instance._narationText.text = _narationList[i];
                i++;
            }
            else
            {
                Debug.Log("자를 수 있음");
            }
        }
    }
}

