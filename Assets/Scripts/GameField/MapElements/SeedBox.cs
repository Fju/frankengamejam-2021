using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Plant;

public class SeedBox : Tile
{
    public PlantType type;

    public override void Interaction(PlayerContoller gameObject)
    {
        if (gameObject.InHand == null)          //Player has no object
        {
            gameObject.InHand = this;
        }
        else if (gameObject.InHand.TileObject == MapObjects.SeedBox)
        {
            gameObject.InHand = null;
        }
    }
   
}
