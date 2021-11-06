using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private void Update()
    {
        var rotation = this.transform.rotation.eulerAngles.y;
        
        if (rotation < 45)
        {
            //this left top
        }
        else if (rotation < 90)
        {
            //this top
        }
        else if (rotation < 135)
        {

        }
        else if (rotation < 180)
        {

        }
        else if (rotation < 225)
        {

        }
        else if (rotation < 270)
        {

        }
        else if (rotation < 315)
        {

        }
        else if (rotation < 360)
        {

        }
        

    }
}
