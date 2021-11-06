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
    public float maxX = 0f;

    public float minZ = 0f;
    public float maxZ = 0f;

    public GameObject playerObject;
    public LevelCreator levelCreator;

    public float normalHeight = 0f;

    private float desiredAngle = 0f;
    private Vector2 direction;

    private void Start()
    {
        direction = new Vector2(0, 0);
        levelCreator = GameObject.Find("/RootEvent/GameField").GetComponent<LevelCreator>();
    }

    void Update()
    {
        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * PlayerSpeed * Time.deltaTime);

        direction = 0.95f * direction + 0.05f * movementInput;
        
        if (direction.magnitude > 1f)
        {
            direction = direction / direction.magnitude;
        }
            
        desiredAngle = (360f + 90f - Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x)) % 360f;
        
        // -z = down | +z = up (movementInput.y)
        // -x = left | +x = right (movementInput.x)
        // 0 deg = up | 90deg = right | -90 deg = 270 deg = left


        float currentAngle = (360f + playerObject.transform.eulerAngles.y) % 360f;
        
        float angleDelta = desiredAngle - currentAngle;

        if (angleDelta > 180f)
        {
            angleDelta -= 360f;
        }
        else if (angleDelta < -180f)
        {
            angleDelta += 360f;
        }

        angleDelta = Mathf.Clamp(angleDelta, -1250 * Time.deltaTime, 1250 * Time.deltaTime);
        playerObject.transform.Rotate(new Vector3(0, angleDelta, 0));



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


        float playerRotation = playerObject.transform.eulerAngles.y;
        Vector2 hitPoint = new Vector2(transform.position.x, transform.position.z);
        hitPoint += new Vector2(Mathf.Cos(playerRotation), Mathf.Sin(playerRotation));

        for (int i = 0; i < levelCreator.GameObjects.Count; ++i)
        {
            GameObject activeGameObject = levelCreator.GameObjects[i];
            Vector3 activePosition = levelCreator.Positions[i];

            if (hitPoint.x > activePosition.x - 0.5f && hitPoint.x < activePosition.x + 0.5f && hitPoint.y > activePosition.z - 0.5f && hitPoint.y < activePosition.z + 0.5f)
            {
                Debug.Log(i);
            }
        }

    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
}
