using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ScriptableObjectArchitecture;

public class SunHealth : MonoBehaviour, IHittable
{


    [SerializeField]
    public GameEvent OnSunDeath;
    [SerializeField]
    public GameEvent OnSunHit;

    public int HealthLeft { get { return HitsLeft; } }
    public int MaxHealth { get { return MaxHitsLeft; } }

    private int HitsLeft = 3;
    private const int MaxHitsLeft = 3;

    private bool IFrame;



    public void OnBulletHit(GameObject hitter)
    {
        if (IFrame)
            return;

        HitsLeft--;
        StartCoroutine(IFrameRoutine());

        if(HitsLeft == 0)
        {
            OnSunDeath?.Raise();
        }
        else
        {
            OnSunHit?.Raise();
            StartCoroutine(GettingHitVisualRoutine());
        }

    }


    public void ResetHealth()
    {
        HitsLeft = MaxHitsLeft;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GettingHitVisualRoutine()
    {
        yield return null;

        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(3f/60f);

        Time.timeScale = 1;

    }

    IEnumerator IFrameRoutine()
    {
        IFrame = true;
        yield return new WaitForSeconds(0.3f);
        IFrame = false;
    }
}
