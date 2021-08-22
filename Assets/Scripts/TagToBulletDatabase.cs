using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class TagToBulletDatabase : ScriptableObject
{

    public Dictionary<string, GameObject> tagToBullet;

    public List<GameObject> Bullets;

    public void RefreshDatabase()
    {
        tagToBullet = new Dictionary<string, GameObject>();
        for (int i = 0; i < Bullets.Count; i++)
        {
            tagToBullet.Add(Bullets[i].tag, Bullets[i]);
        }
    }

    private void OnEnable()
    {
        RefreshDatabase();
    }
}
