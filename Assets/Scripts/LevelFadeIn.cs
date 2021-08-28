using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LevelFadeIn : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {

        StartCoroutine(FadeInLogic());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeInLogic()
    {
        Image image = GetComponent<Image>();
        image.CrossFadeAlpha(0, 0.5f, false);
        yield return new WaitForSeconds(0.5f);
        Destroy(transform.parent.gameObject);

    }
}
