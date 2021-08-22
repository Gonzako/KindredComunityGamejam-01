using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAnimation : MonoBehaviour
{
    [SerializeField]
    ScriptableObjectArchitecture.FloatVariable RotationSpeed;

    public float MaxRotation = 20f;

    private Vector2 playerInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = getDesiredRotation(playerInput);
    }

    public void RecievePlayerInput(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        playerInput = ctx.ReadValue<Vector2>();
    }

    Quaternion getDesiredRotation(Vector2 playerInput)
    {
        Quaternion desiredRot = Quaternion.Euler(MaxRotation*playerInput.y, -playerInput.x * MaxRotation, 0);
        return Quaternion.Slerp(transform.rotation, desiredRot, 1 - Mathf.Exp(-RotationSpeed.Value * Time.deltaTime));
    }
}
