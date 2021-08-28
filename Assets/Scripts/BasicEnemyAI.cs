using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BasicEnemyAI : EnemyBaseAI
{
    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override IEnumerator BehaviourRoutine()
    {
        yield return new WaitForSeconds(0.2f);

        while (true)
        {
            yield return StartCoroutine(MoveToPoint());
            HandleShots();
            yield return new WaitForSeconds(0.5f);
            HandleShots();
            UseSun = !UseSun;
        }
    }

    protected virtual IEnumerator MoveToPoint()
    {
        var duration = 1f;
        var MoveTween = transform.DOMove((Vector2)UtilityScripts.RandomPointInBounds(allowedBounds), duration).SetEase(Ease.InOutQuint);
        yield return new WaitForSeconds(duration/2);
        HandleShots();
        yield return new WaitUntil(() => !MoveTween.IsPlaying());
    }


}
