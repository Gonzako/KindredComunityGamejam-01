using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class EnemySpawnSystem : MonoBehaviour
{

    [SerializeField]
    EnemyBaseAI BasicEnemy;
    [SerializeField]
    EnemyBaseAI AllWayShip;
    [SerializeField]
    EnemyBaseAI Boss;

    [SerializeField]
    Collider2D LeftBounds;
    [SerializeField]
    Collider2D MiddleBounds;
    [SerializeField]
    Collider2D RightBounds;

    [SerializeField]
    IntVariable WaveCount;

    [SerializeField]
    Transform SpawnPoint;



    public void SpawnWave()
    {
        switch (WaveCount.Value)
        {
            case 0:
                StartCoroutine(Count0Spawn());
                break;
            case 1:
                StartCoroutine(Count1Spawn());
                break;
            case 2:
                StartCoroutine(Count2Spawn());
                break;
            case 3:
                StartCoroutine(Count3Spawn());
                break;
            case 4:
                StartCoroutine(Count4Spawn());
                break;
            default:
                StartCoroutine(WaveSpawn());
                break;

        }

        WaveCount.Value += 1;
    }

    private IEnumerator Count4Spawn()
    {
        yield return null;
        var t = GameObject.Instantiate(Boss, SpawnPoint);
        t.allowedBounds = MiddleBounds.bounds;
        t.gameObject.SetActive(true);
    }

    private void Start()
    {
        WaveCount.Value = 0;
        SpawnWave();
    }

    private IEnumerator Count0Spawn()
    {
        yield return null;
        var t = GameObject.Instantiate(BasicEnemy, SpawnPoint);
        t.allowedBounds = MiddleBounds.bounds;
        t.gameObject.SetActive(true);
    }
    private IEnumerator Count1Spawn()
    {
        yield return null;
        var t = GameObject.Instantiate(AllWayShip, SpawnPoint);
        t.allowedBounds = MiddleBounds.bounds;
        t.gameObject.SetActive(true);
    }

    private IEnumerator Count2Spawn()
    {
        List<Bounds> boundList = new List<Bounds> { MiddleBounds.bounds, LeftBounds.bounds, RightBounds.bounds };
        for (int i = 0; i < 3; i++)
        {
            var t = GameObject.Instantiate(BasicEnemy, SpawnPoint);
            t.allowedBounds = boundList[i];
            t.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
    }
    private IEnumerator Count3Spawn()
    {
        List<Bounds> boundList = new List<Bounds> { MiddleBounds.bounds, LeftBounds.bounds, RightBounds.bounds };
        for (int i = 0; i < 3; i++)
        {
            var t = GameObject.Instantiate(i == 0 ? BasicEnemy : AllWayShip, SpawnPoint);
            t.allowedBounds = boundList[i];
            t.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator WaveSpawn()
    {
        var waveScore = WaveCount.Value;
        while (waveScore > 0)
        {
            EnemyBaseAI t;
            if(waveScore == 1)
            {
                t = GameObject.Instantiate(BasicEnemy, SpawnPoint);
                waveScore = 0;
            }
            else
            {

                var target = GetRandomPrefab();
                while (waveScore < target.Item2 && target.Item2 != 0)
                {
                    target = GetRandomPrefab();
                }
                t = GameObject.Instantiate(target.Item1, SpawnPoint);
                waveScore -= target.Item2;
            }


            t.allowedBounds = GetRandomBounds();
            t.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private (EnemyBaseAI, int) GetRandomPrefab()
    {
        int value = Random.Range(1, 5);

        switch (value)
        {

            case 1:
                return (BasicEnemy, value);
            case 2:

                return (AllWayShip, value);
            case 3:

                return (BasicEnemy, 1);
            case 4:
                return (Boss, value);

        }
        return (null,0);
    }

    private Bounds GetRandomBounds()
    {

        int value = Random.Range(0, 3);
        List<Bounds> boundList = new List<Bounds> { MiddleBounds.bounds, LeftBounds.bounds, RightBounds.bounds};
        return boundList[value];

    }
}
