using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class ZLevelManager : MonoBehaviour
{

#if UNITY_EDITOR
    private void Update()
    {
        transform.position = (Vector2)transform.position;
    }
#endif
}
