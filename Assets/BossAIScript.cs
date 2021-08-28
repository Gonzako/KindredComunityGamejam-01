using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class BossAIScript : EnemyBaseAI
{
    [SerializeField]
    private List<BulletSpawner> FrontSunShooter;
    [SerializeField]
    private List<BulletSpawner> FrontMoonShooter;

    [SerializeField]
    UnityEvent OnStartFiringLaser;
    [SerializeField]
    UnityEvent OnFinishFiringLaser;

    private const float MoveTime = 4f;
    protected override IEnumerator BehaviourRoutine()
    {
        StartCoroutine(LaserRoutine());
        StartCoroutine(ShotRoutine());
        var posX = transform.position.x;
        var targetPoint = allowedBounds.center.x + allowedBounds.size.x;
        var distanceToPoint = targetPoint - posX;
        var t = transform.DOMoveX(allowedBounds.center.x + allowedBounds.size.x * 0.6f, MoveTime *(distanceToPoint/allowedBounds.size.x*2));
        yield return new WaitUntil(() => !t.IsPlaying());
        while (true)
        {
            t = transform.DOMoveX(allowedBounds.center.x - allowedBounds.size.x * 0.6f, MoveTime);
            yield return new WaitUntil(() => !t.IsPlaying());

            t = transform.DOMoveX(allowedBounds.center.x + allowedBounds.size.x * 0.6f, MoveTime);
        }
    }

    IEnumerator LaserRoutine()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            OnStartFiringLaser.Invoke();
            for (int i = 0; i < FrontSunShooter.Count; i++)
            {
                FrontSunShooter[i].CreateShot();
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(0.05f);
            for (int j = FrontMoonShooter.Count-1; j >= 0; j--)
            {
                FrontMoonShooter[j].CreateShot();
                yield return new WaitForSeconds(0.05f);
                Debug.Log("MoonLaserCalled");
            }
            OnFinishFiringLaser.Invoke();
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator ShotRoutine()
    {
        if (UseSun)
        {
            for (int i = 0; i < 3; i++)
            {
                SunShots[i].CreateShot();
            }
            yield return new WaitForSeconds(0.25f);
            for(int i = 3; i<6; i++)
            {
                MoonShots[i].CreateShot();
            }
            yield return new WaitForSeconds(1f);
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                MoonShots[i].CreateShot();
            }
            yield return new WaitForSeconds(0.25f);
            for (int i = 3; i < 6; i++)
            {
                SunShots[i].CreateShot();
            }
            yield return new WaitForSeconds(1f);
        }
        UseSun = !UseSun;
        StartCoroutine(ShotRoutine());
    }
}
