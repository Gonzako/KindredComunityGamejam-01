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
    }

    private void OnCollisionEnter(Collision collision)
    {
        var hittable = collision.gameObject.GetComponent<IHittable>();

        if (hittable != null) 
        { 
            hittable.OnBulletHit(this.gameObject);
            OnBulletHit.Invoke();
        }
    }
}
