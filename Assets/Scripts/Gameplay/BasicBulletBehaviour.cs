using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicBulletBehaviour : MonoBehaviour
{

    public float speed;
    public UnityEvent OnBulletHit;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rb.velocity = transform.right * speed;
        StartCoroutine(Cleanup());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hittable = collision.gameObject.GetComponent<IHittable>();

        if (hittable != null) 
        { 
            hittable.OnBulletHit(this.gameObject);
            OnBulletHit.Invoke();
        }
        StoreInPool();
    }


    private void StoreInPool()
    {
        BulletPooler.Instance.AddBullet(this);

    }

    private IEnumerator Cleanup()
    {
        yield return new WaitForSeconds(10);
        StoreInPool();
    }
}
