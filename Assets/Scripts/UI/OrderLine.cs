using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderLine : MonoBehaviour
{
    public TextMeshProUGUI quantityTextObject;

    public int quantity;
    public string fruit;

    public void Start()
    {
        quantityTextObject.SetText(string.Format("{0}x", quantity));
    }

}
