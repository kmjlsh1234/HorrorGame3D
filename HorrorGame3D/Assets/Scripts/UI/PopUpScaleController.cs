using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PopUpScaleController : MonoBehaviour
{
    [SerializeField] private Vector3 _endScale;
    [SerializeField] private float _timer;
    private void OnEnable()
    {
        this.transform.localScale = new Vector3(0f, 0f, 0f);

        this.transform.DOScale(_endScale, _timer);
    }
}
