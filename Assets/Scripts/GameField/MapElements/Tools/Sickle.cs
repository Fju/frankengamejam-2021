using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sickle : Tile
{
    public bool HasSickle;
    public GameObject SickleObject;

    public override void Interaction(PlayerContoller gameObject)
    {
        if (gameObject.InHand == null && SickleObject.activeSelf)          //Player has no object
        {
            if (HasSickle)                      //This has object
            {
                gameObject.InHand = this;
            }
            SickleObject.SetActive(false);
        }
        else if (gameObject.InHand.TileObject == MapObjects.ToolSickle)
        {
            if (!SickleObject.activeSelf)       //Player has ToolWaterCan
            {
                SickleObject.SetActive(true);
                gameObject.InHand = null;
            }
        }
    }
}
