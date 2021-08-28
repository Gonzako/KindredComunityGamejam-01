using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TimerUIVisualizer : MonoBehaviour
{
    // Start is called before the first frame update
    Tween t;
    void Start()
    {
        t = transform.DOScaleX(0, 13).SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public void restartTimer()
    {
        t.Kill();
        transform.localScale = Vector3.one;
        t = transform.DOScaleX(0, 13).SetEase(Ease.Linear);
    }
}
