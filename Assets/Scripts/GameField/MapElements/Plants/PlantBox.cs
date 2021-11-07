using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBox : Tile
{
    public GameObject plantElement;
    public GameObject planeFinish;
    public GameObject planeFinishFruit;
    public float plantTimer;
    public bool startTimer;
    public bool plantFinished;
    public bool plantFinishedFinished;

    public void Update()
    {
        if (startTimer)
        {
            plantTimer += Time.deltaTime;
            if (plantTimer > 10)
            {
                startTimer = false;
                plantElement.SetActive(false);
                planeFinish.SetActive(true);
                plantFinished = true;
            }
        }
    }

    public override void Interaction(PlayerContoller gameObject)
    {
        if (gameObject.InHand == null && plantFinishedFinished)           //Player has no object
        {
            gameObject.InHand = planeFinishFruit.GetComponent<Tile>();
            planeFinishFruit.SetActive(false);
            plantFinishedFinished = false;
        }
        else if (gameObject.InHand.TileObject == MapObjects.SeedBox)
        {
            if (!plantElement.activeSelf)                                   //Player has ToolWaterCan
            {
                plantElement.SetActive(true);
                gameObject.InHand = null;
                startTimer = true;
            }
        }
        else if (gameObject.InHand.TileObject == MapObjects.ToolSickle) {
            if (plantFinished) {
                plantElement.SetActive(false);
                planeFinish.SetActive(false);
                planeFinishFruit.SetActive(true);
                plantFinishedFinished = true;
            }
        }
    }
}
