using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SunHitVisuals : MonoBehaviour
{

    private Vector3 toIncreaseAmount = new Vector3(0.15f, 0.15f, 0.15f);

    public void OnHit()
    {
        transform.DOScale(transform.localScale + toIncreaseAmount, 0.2f).SetEase(Ease.OutBack);
    }


    public void OnReset()
    {
        transform.localScale = Vector3.one;
    }
}
