using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class MoonHitLogic : MonoBehaviour, IHittable
{




    [SerializeField]
    public GameEvent OnMoonDeath;
    [SerializeField]
    public GameEvent OnMoonHit;

    public int HealthLeft { get { return HitsLeft; } }
    public int MaxHealth { get { return MaxHitsLeft; } }

    private int HitsLeft = 3;
    private const int MaxHitsLeft = 3;

    private bool Iframe;


    public void OnBulletHit(GameObject hitter)
    {
        HitsLeft--;
        

        if (HitsLeft == 0)
        {
            OnMoonDeath?.Raise();
        }
        else
        {
            OnMoonHit?.Raise();
            StartCoroutine(GettingHitVisualRoutine());
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTimerReset()
    {
        HitsLeft = MaxHitsLeft;
    }
    IEnumerator GettingHitVisualRoutine()
    {
        yield return null;

        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(0.025f);

        Time.timeScale = 1;

    }
}
