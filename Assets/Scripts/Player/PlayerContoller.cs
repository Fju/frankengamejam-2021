using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContoller : MonoBehaviour
{
    public int PlayerSpeed = 1;
    public float TurnSpeed = 180f;

    public Vector2 movementInput;
    public float rotationInput;

    public float minX = 0f;
    public float maxX = 0f;

    public float minZ = 0f;
    public float maxZ = 0f;

    public float normalHeight = 0f;
    
    void Update()
    {
        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * PlayerSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, rotationInput * TurnSpeed, 0));


        if (this.transform.position.x < minX)
        {
            this.transform.position = new Vector3(minX, normalHeight, transform.position.z);
        }
        else if (this.transform.position.x > maxX)
        {
            this.transform.position = new Vector3(maxX, normalHeight, transform.position.z);
        }

        if (this.transform.position.z < minZ)
        {
            this.transform.position = new Vector3(transform.position.x, normalHeight, minZ);
        }
        else if (this.transform.position.z > maxZ)
        {
            this.transform.position = new Vector3(transform.position.x, normalHeight, maxZ);
        }

        if (this.transform.position.y > normalHeight)
        {
            this.transform.position = new Vector3(transform.position.x, normalHeight, transform.position.z);
        }
        if (this.transform.position.y < normalHeight)
        {
            this.transform.position = new Vector3(transform.position.x, normalHeight, transform.position.z);
        }
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
    public void OnRotation(InputAction.CallbackContext ctx) => rotationInput = ctx.ReadValue<float>();
}
