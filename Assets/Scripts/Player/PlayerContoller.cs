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

    public GameObject Sickle;
    public GameObject WateringCan;
    public GameObject Seed;

    public float normalHeight = 0f;

    private float desiredAngle = 0f;
    private Vector2 direction;

    private Tile interactable = null;
    private Tile m_inHand = null;

    private float TimeSinceLastInteraction = 0.5f;

    public Tile InHand
    {
        set
        {
            m_inHand = value;

            Sickle.SetActive(false);
            WateringCan.SetActive(false);
            Seed.SetActive(false);

            if (m_inHand.TileObject == MapObjects.ToolSickle)
            {
                Sickle.SetActive(true);
            }
            if (m_inHand.TileObject == MapObjects.ToolWateringCan)
            {
                WateringCan.SetActive(true);
            }
            if (m_inHand.TileObject == MapObjects.SeedBox)
            {
                Seed.SetActive(true);
            }
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
            interactable.Interaction(this);
        }
    }

    void Update()
    {
        //Triggered by UserInput System R or Left Trigger
        TimeSinceLastInteraction += Time.deltaTime;
        if (interaction == 1 && TimeSinceLastInteraction > 0.2f)
        {
            TimeSinceLastInteraction = 0;
            Interaction();
        }
        
       

        direction = 0.85f * direction + 0.15f * movementInput;
        
        if (direction.magnitude > 1f)
        {
            direction = direction / direction.magnitude;
        }


        transform.Translate(new Vector3(direction.x, 0, direction.y) * PlayerSpeed * Time.deltaTime);
            
        if (direction.magnitude > 0.1f)
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
        }
        
        interactable = null;
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
            highlightLightInstance.transform.position = new Vector3(lightPosition.Value.x, lightPosition.Value.y + 0.7f, lightPosition.Value.z);
        }
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
    
    public void OnAction(InputAction.CallbackContext ctx) => interaction = ctx.ReadValue<float>();
}
