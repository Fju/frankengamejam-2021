using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public GameObject barObject;

    public void setProgress(float value)
    {
        barObject.transform.localScale = new Vector3(value, 1, 1);
        Image imageObject = barObject.GetComponent<Image>();

        if (value > 0.5f)
        {
            imageObject.color = new Color(0.11f, 0.58f, 0.05f);
        } else if (value > 0.2f)
        {
            imageObject.color = new Color(0.83f, 0.47f, 0.13f);
        } else
        {
            imageObject.color = new Color(1f, .25f, .25f);
        }
    }
}
