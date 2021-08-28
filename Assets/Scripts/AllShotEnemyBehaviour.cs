using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AllShotEnemyBehaviour : EnemyBaseAI
{
    

    protected override IEnumerator BehaviourRoutine()
    {
        StartCoroutine(ShotRoutine());


        do
        {
            var tween = transform.DOMove((Vector2)UtilityScripts.RandomPointInBounds(allowedBounds), 1.6f);
            yield return new WaitUntil(() => !tween.IsPlaying());

        } while (true);
    }

    IEnumerator ShotRoutine()
    {
        yield return new WaitForSeconds(0.4f);
        HandleShots();
        yield return new WaitForSeconds(0.6f);
        StartCoroutine(ShotRoutine());
    }

    private void Update()
    {
        transform.rotation *= Quaternion.Euler(0, 0, 3*Time.deltaTime);
    }

    protected override void HandleShots()
    {
        
        for (int i = 0; i < MoonShots.Count; i++)
        {
            if (UseSun)
            {
                SunShots[i].CreateShot();
            }
            else
            {
                MoonShots[i].CreateShot();
            }
            UseSun = !UseSun;
        }

    }
}
