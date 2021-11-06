using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContoller : MonoBehaviour
{
    public int PlayerSpeed = 1;
    public float TurnSpeed = 180f;
    public Vector2 movementInput;

    public float minX = 0f;
    public float minY = 0f;
    public float maxX = 0f;
    public float maxY = 0f;
    public float normalHeight = 0f;
    
    void Update()
    {
        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * PlayerSpeed * Time.deltaTime);

        if (this.transform.position.x < minX)
        {
            this.transform.position = new Vector3(minX, normalHeight, transform.position.z);
        }
        else if (this.transform.position.x > maxX)
        {
            this.transform.position = new Vector3(maxX, normalHeight, transform.position.z);
        }
        



    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
}
