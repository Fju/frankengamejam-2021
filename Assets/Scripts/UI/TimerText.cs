using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerText : MonoBehaviour
{
    public void updateTimer(int minutes, int seconds)
    {
        // get textmeshpro object
        TextMeshProUGUI tmpObject = this.GetComponent<TextMeshProUGUI>();

        // format seconds, fill with preceding zeros if the seconds are smaller than 10
        string secondsStr = seconds.ToString();
        while (secondsStr.Length < 2) secondsStr = "0" + secondsStr;

        // update text content
        tmpObject.SetText(string.Format("{0}:{1}", minutes, secondsStr));

        // set text color to red if the seconds are less than 10
        if (minutes < 1 && seconds < 10)
        {
            tmpObject.color = new Color(0.9f, 0.13f, 0.25f);
        } else
        {
            tmpObject.color = new Color(1f, 1f, 1f);
        }
    }
}
