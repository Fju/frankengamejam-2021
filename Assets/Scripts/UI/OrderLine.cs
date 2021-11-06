using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderLine : MonoBehaviour
{
    public TextMeshProUGUI quantityTextObject;

    public void setContent(int quantity, string fruit)
    {
        quantityTextObject.SetText(string.Format("{0}x {1}", quantity, fruit));
    }

}
