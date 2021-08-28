using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class EnemyHealth : MonoBehaviour, IHittable
{
    public UnityEvent OnHit;
    public UnityEvent OnDeath;
    public int MaxHealth = 5;
    private int currentHealth;

    public void OnBulletHit(GameObject hitter)
    {

        currentHealth--;

        if(currentHealth < 0)
        {
            OnDeath.Invoke();
        }
        else
        {
            OnHit.Invoke();
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
