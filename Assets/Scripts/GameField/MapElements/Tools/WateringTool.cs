using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringTool : Tile
{
    public bool HasCan;
    public GameObject CanObject;

    public override void Interaction(PlayerContoller gameObject, Tile InPlayerHand)
    {
        if (InPlayerHand == null)   //Player has no object
        {
            if (HasCan)             //This has object
            {
                gameObject.InHand = this;   
            }
            CanObject.SetActive(false);
        }
        else
        {
            if (InPlayerHand.TileObject == MapObjects.ToolWateringCan)  //Player has ToolWaterCan
            {
                CanObject.SetActive(true); 
                InPlayerHand = null;
            }
        }
    }
}
