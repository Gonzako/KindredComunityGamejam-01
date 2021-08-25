using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooler : MonoBehaviour
{

    public static BulletPooler Instance { get { if (_Instance == null) { SetupInstance(); } return _Instance; } private set { _Instance = value; } }
    private static BulletPooler _Instance;

    Dictionary<string, List<BasicBulletBehaviour>> BulletData = new Dictionary<string, List<BasicBulletBehaviour>>();
    Dictionary<string, GameObject> tagToGO = new Dictionary<string, GameObject>();
    public static void SetupInstance()
    {
        if(_Instance == null)
        {
            var go = new GameObject("Bullet Pooler");
            _Instance = go.AddComponent<BulletPooler>();
        }
    }

    private void OnDisable()
    {
        if(Instance == this)
        {
            Instance = null;
        }
    }

    private void OnEnable()
    {
        if(_Instance == this || _Instance == null)
        {
            Instance = this;

            var t = Resources.Load<TagToBulletDatabase>("BulletDataBase");
            t.RefreshDatabase();
            tagToGO = t.tagToBullet;

            foreach (KeyValuePair<string, GameObject> entry in tagToGO)
            {
                BulletData.Add(entry.Key, new List<BasicBulletBehaviour>());
            }
        }
    }

    public void AddBullet(BasicBulletBehaviour Bullet)
    {
        BulletData[Bullet.tag].Add(Bullet);
        Bullet.gameObject.SetActive(false);
    }

    public BasicBulletBehaviour GetBullet(string tag)
    {
        if(BulletData[tag].Count > 0)
        {
            var target = BulletData[tag][0];
            BulletData[tag].RemoveAt(0);
            return target;
        }
        else
        {
            var target = GameObject.Instantiate(tagToGO[tag]);
            target.transform.parent = transform;
            target.SetActive(false);
            return target.GetComponent<BasicBulletBehaviour>();
        }
    }
}
