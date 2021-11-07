using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBox : Tile
{
    public bool HasSickle;
    public GameObject plantElement;

    public override void Interaction(PlayerContoller gameObject)
    {
        if (gameObject.InHand == null && plantElement.activeSelf)           //Player has no object
        {
            if (HasSickle)                                                  //This has object
            {
                gameObject.InHand = this;
            }
            plantElement.SetActive(false);
        }
        else if (gameObject.InHand.TileObject == MapObjects.SeedBox)
        {
            if (!plantElement.activeSelf)                                   //Player has ToolWaterCan
            {
                plantElement.SetActive(true);
                gameObject.InHand = null;
            }
        }
    }
}
