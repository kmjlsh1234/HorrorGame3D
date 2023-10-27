using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager;

namespace Assets.Scripts.Object
{
    
    public class HouseDoor : ObjectBase
    {
        [SerializeField] private string[] _narationList;
        int i = 0;
        public override void SetInteraction()
        {
            if (i == 0)
            {
                CanvasManager.Instance._textPanel.SetActive(true);

            }
            else if (i == _narationList.Length)
            {
                CanvasManager.Instance._textPanel.SetActive(false);
                CanvasManager.Instance.FadeInOut();
                gameObject.SetActive(false);
                Debug.Log("������ �� ������ ����");
                i++;
                return;

            }
            else if (i > _narationList.Length)
                return;

            CanvasManager.Instance._narationText.text = _narationList[i];
            i++;
        }
    }
}

