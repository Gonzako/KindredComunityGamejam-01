using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletSpawner : MonoBehaviour
{

    [SerializeField]
    string Tag;
    [SerializeField, Range(0.01f, 1)]
    float timeBetweenShots;

    [SerializeField]
    UnityEvent OnShotRequested;

    bool pressed;
    float timer;

    public void GatherPlayerInput(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        pressed = ctx.ReadValueAsButton();
    }


    private void Update()
    {
        if (pressed)
        {
            if(Time.time > timer)
            {
                timer = Time.time + timeBetweenShots;

                CreateShot();
            }
        }
    }

    public void CreateShot()
    {
        OnShotRequested.Invoke();
        var target = BulletPooler.Instance.GetBullet(Tag);
        target.transform.position = transform.position;
        target.transform.right = transform.right;
        target.gameObject.SetActive(true);

    }
}
