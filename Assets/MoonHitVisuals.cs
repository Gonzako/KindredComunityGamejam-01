using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoonHitVisuals : MonoBehaviour
{
    private Vector3 toIncreaseAmount = new Vector3(0.15f, 0.15f, 0.15f);
    Tween t;
    public void OnHit()
    {
        t = transform.DOScale(transform.localScale - toIncreaseAmount, 0.2f).SetEase(Ease.OutSine);
    }


    public void OnReset()
    {
        t.Kill();
        transform.localScale = Vector3.one * 0.75f;
    }
}
