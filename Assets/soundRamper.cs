using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class soundRamper : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        var audio = GetComponent<AudioSource>();

            audio.volume = 0;
        DOTween.To(()=>audio.volume, x=> audio.volume = x,1f, 0.5f);
    }

}
