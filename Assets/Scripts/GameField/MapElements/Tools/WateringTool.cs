using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringTool : Tile
{
    public bool HasCan;
    public GameObject CanObject;

    public override void Interaction(PlayerContoller gameObject)
    {
        if (gameObject.InHand == null && CanObject.activeSelf)          //Player has no object
        {
            if (HasCan)                                                 //This has object
            {
                gameObject.InHand = this;   
            }
            CanObject.SetActive(false);
        }
        else if (gameObject.InHand.TileObject == MapObjects.ToolWateringCan)
        {
            if (!CanObject.activeSelf)                                  //Player has ToolWaterCan
            {
                CanObject.SetActive(true);
                gameObject.InHand = null;
            }
        }
    }
}
