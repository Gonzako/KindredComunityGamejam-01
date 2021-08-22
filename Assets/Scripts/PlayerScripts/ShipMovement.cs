using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{

    [SerializeField]
    FloatVariable Speed;
    [SerializeField]
    FloatVariable RampUpSpeed;

    Rigidbody2D _rb;
    Vector2 desiredSpeed;
    Vector2 currentSpeed;
    Vector2 playerInput;
    // Start is called before the first frame update
    void Start()
    {

        _rb = GetComponent<Rigidbody2D>();
       
    }



    public void GatherPlayerInput(InputAction.CallbackContext ctx)
    {
        playerInput = ctx.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if(playerInput.magnitude > 0)
            _rb.velocity = calculateVelocity(playerInput, _rb);
    }

    private Vector2 calculateVelocity(Vector2 playerInput, Rigidbody2D rb)
    {
        var desiredSpeed = playerInput.normalized * Speed.Value;
        var currentSpeed = rb.velocity;
        var nextSpeed = Vector2.Lerp(currentSpeed, desiredSpeed, 1 - Mathf.Exp(-RampUpSpeed.Value * Time.deltaTime));
        return nextSpeed;
    }
}
