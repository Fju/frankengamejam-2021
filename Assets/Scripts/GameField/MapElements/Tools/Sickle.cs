using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sickle : Tile
{
    public bool HasSickle;
    public GameObject SickleObject;

    public override void Interaction(PlayerContoller gameObject, Tile InPlayerHand)
    {
        if (InPlayerHand == null)   //Player has no object
        {
            if (HasSickle)             //This has object
            {
                gameObject.InHand = this;
            }

            SickleObject.SetActive(false);
        }
        else
        {
            if (!SickleObject.activeSelf) //Player has ToolWaterCan
            {
                SickleObject.SetActive(true);
            }
            InPlayerHand = null;
        }
    }
}
