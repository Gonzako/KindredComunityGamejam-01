using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class TransitionAnimation : MonoBehaviour
{

    [SerializeField]
    GameObject SunGO;
    [SerializeField]
    GameObject MoonGO;

    [SerializeField]
    Transform Sun2Place;
    [SerializeField]
    Transform Moon2Place;

    [SerializeField]
    ScriptableObjectArchitecture.GameEvent OnStartLevelAnimation;


    bool setOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryStartGame()
    {
        if (!setOnce)
        {
            setOnce = true;
        }
        else
        {
            OnStartLevelAnimation.Raise();
            StartCoroutine(MoveToLevelOneAnimation());
        }
    }

    private IEnumerator MoveToLevelOneAnimation()
    {
        var canvasGroup = GetComponent<CanvasGroup>();

        var tween = canvasGroup.DOFade(0, 0.8f);

        SunGO.transform.position = Sun2Place.position;
        MoonGO.transform.position = Moon2Place.position;

        SunGO.SetActive(true);
        MoonGO.SetActive(true);

        yield return new WaitForSeconds(0.4f);

        SunGO.transform.DOLocalMove(Vector2.left*0.5f, 1f).SetEase(Ease.InOutQuint);
        MoonGO.transform.DOLocalMove(Vector2.left*-0.5f, 1f).SetEase(Ease.InOutQuint);
    }
}
