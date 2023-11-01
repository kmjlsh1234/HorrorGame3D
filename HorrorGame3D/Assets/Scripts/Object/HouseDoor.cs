using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager;

namespace Assets.Scripts.Object
{
    
    public class HouseDoor : ObjectBase
    {
        [SerializeField] private string[] _narationList;
        [SerializeField] private Vector3 _nextPlayerPosition;
        [SerializeField] private string _nextMapName;
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
                MapManager.Instance.LoadMapData(_nextMapName, _nextPlayerPosition);
                gameObject.SetActive(false);
                Debug.Log("마녀의 집 안으로 들어가기");
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

