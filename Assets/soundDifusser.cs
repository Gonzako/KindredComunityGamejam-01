using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class soundDifusser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startDiffusingMusic(float time = 1.4f)
    {
        var audioSource = GetComponent<AudioSource>();
        audioSource.DOFade(0, time);
    }
}
