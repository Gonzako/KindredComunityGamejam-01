using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletSpawner : MonoBehaviour
{

    [SerializeField]
    string Tag;
    [SerializeField, Range(0.01f, 1)]
    float timeBetweenShots;


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
        var target = BulletPooler.Instance.GetBullet(Tag);
        target.transform.position = transform.position;
        target.transform.right = transform.right;
        target.gameObject.SetActive(true);

    }
}
