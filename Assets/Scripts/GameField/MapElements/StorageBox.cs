using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageBox : Tile
{
    public FruitStack fruitStack;
    public void Interaction()
    {

    }
    public override void Interaction(PlayerContoller gameObject, Tile InPlayerHand)
    {
        throw new System.NotImplementedException();
    }
}
