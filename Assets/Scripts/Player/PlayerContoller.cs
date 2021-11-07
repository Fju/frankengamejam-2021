using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContoller : MonoBehaviour
{
    public int PlayerSpeed = 1;
    public float TurnSpeed = 180f;
    public Vector2 movementInput;
    public float interaction;

    public float minX = 0f;
    public float maxX = 0f;

    public float minZ = 0f;
    public float maxZ = 0f;

    public GameObject playerObject;
    public LevelCreator levelCreator;
    public GameObject highlightLight;
    public GameObject highlightLightInstance;

    public float normalHeight = 0f;

    private float desiredAngle = 0f;
    private Vector2 direction;

    private Tile interactable = null;
    private Tile m_inHand = null;

    public Tile InHand
    {
        set
        {
            m_inHand = value;
        }
        get
        {
            return m_inHand;
        }
    }

    private void Start()
    {
        direction = new Vector2(0, 0);
        levelCreator = GameObject.Find("/GameObjects/LevelCreator").GetComponent<LevelCreator>();
    }

    private void Interaction()
    {
        if (interactable != null)
        {
            interactable.Interaction(this, InHand);
        }
    }

    void Update()
    {
        //Triggered by UserInput System R or Left Trigger
        if (interaction == 1)
        {
            Interaction();
        }
        
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
        playerObject.transform.Rotate(new Vector3(0, 0, angleDelta));

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


        float playerRotation = 90f - playerObject.transform.eulerAngles.y;
        Vector3 hitPoint = new Vector3(transform.position.x, 0, transform.position.z);
        hitPoint += (new Vector3(Mathf.Cos(Mathf.Deg2Rad * playerRotation), 0, Mathf.Sin(Mathf.Deg2Rad * playerRotation))) * 0.5f;
        
        int closestIndex = 0;
        float closestDistance = 10f;
        Vector3? lightPosition = null;

        for (int i = 0; i < levelCreator.ObjectInstances.Count; ++i)
        {
            Vector3 activePosition = levelCreator.Positions[i];
            Vector3 distance = hitPoint - activePosition;

            if (distance.magnitude < closestDistance)
            {
                closestIndex = i;
                closestDistance = distance.magnitude;
            }
            Tile tile = levelCreator.ObjectInstances[i];
            lightPosition = tile.position;
            interactable = tile;
        }
        
        if (closestDistance <= 2f)
        {
            Tile tile = levelCreator.ObjectInstances[closestIndex];
            lightPosition = tile.position;
            interactable = tile;
        }

        if (lightPosition == null)
        {
            if (highlightLightInstance != null)
            {
                highlightLightInstance.SetActive(false);
            }
        }
        else
        {
            if (highlightLightInstance == null)
            {
                highlightLightInstance = GameObject.Instantiate(highlightLight);
            }

            highlightLightInstance.SetActive(true);
            highlightLightInstance.transform.position = new Vector3(lightPosition.Value.x, lightPosition.Value.y + 1, lightPosition.Value.z);
        }
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
    
    public void OnAction(InputAction.CallbackContext ctx) => interaction = ctx.ReadValue<float>();
}
