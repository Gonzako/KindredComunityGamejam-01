using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxEffectManager : MonoBehaviour
{

    public Material SkyboxMat;
    [Range(0.01f, 2f)]
    public float Speed;

    private void Update()
    {
        
        AddRotation(SkyboxMat);
    }

    void AddRotation(Material target)
    {
        var rotation = target.GetFloat("_Rotation");

        rotation += Time.fixedDeltaTime*Speed;

        rotation = rotation % 360;

        target.SetFloat("_Rotation", rotation);
    }

}
