using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBox : Tile
{
    public bool HasSickle;
    public GameObject plantElement;

    public override void Interaction(PlayerContoller gameObject)
    {
        if (gameObject.InHand == null)           //Player has no object
        {
            
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
