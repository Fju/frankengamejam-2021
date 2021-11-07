using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : Tile
{
    public bool hasWateringCan;
    public bool hasEUPalette;

    public override void Interaction(PlayerContoller gameObject, Tile InPlayerHand)
    {
        if (InPlayerHand.TileObject == MapObjects.ToolSickle
            || InPlayerHand.TileObject == MapObjects.ToolWateringCan
            )
        {

        }

    }
}
