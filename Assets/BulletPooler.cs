using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooler : MonoBehaviour
{

    public static BulletPooler Instance;

    Dictionary<string, List<BasicBulletBehaviour>> BulletData = new Dictionary<string, List<BasicBulletBehaviour>>();
    Dictionary<string, GameObject> tagToGO = new Dictionary<string, GameObject>();
    public static void SetupInstance()
    {
        if(Instance == null)
        {
            var go = new GameObject("Bullet Pooler");
            go.AddComponent<BulletPooler>();
        }
    }

    private void OnDisable()
    {
        if(Instance == this)
        {
            Instance = null;
            var t = Resources.Load<TagToBulletDatabase>("BulletDataBase");
            t.RefreshDatabase();
            tagToGO = t.tagToBullet;
            
            foreach(KeyValuePair<string, GameObject> entry in tagToGO)
            {
                BulletData.Add(entry.Key, new List<BasicBulletBehaviour>());
            }
        }
    }

    private void OnEnable()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void AddBullet(BasicBulletBehaviour Bullet)
    {
        BulletData[Bullet.tag].Add(Bullet);
        Bullet.gameObject.SetActive(false);
    }

    public void GetBullet(string tag)
    {

    }
}
