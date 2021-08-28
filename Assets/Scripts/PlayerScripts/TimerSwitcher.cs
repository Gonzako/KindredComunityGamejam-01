using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class TimerSwitcher : MonoBehaviour
{

    [SerializeField]
    GameEvent OnTimerTriggered;

    private const int TimerInterval = 13;


    [SerializeField]
    Transform[] sunAndMoon;

    private void Start()
    {
        StartCoroutine(TimerRoutine());
    }

    IEnumerator TimerRoutine()
    {
        yield return new WaitForSeconds(12.95f);
        OnTimerTriggered.Raise();
        var pos = sunAndMoon[1].position;
        sunAndMoon[1].position = sunAndMoon[0].position;
        sunAndMoon[0].position = pos;
        StartCoroutine(TimerRoutine());
    }
}
