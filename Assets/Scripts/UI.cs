using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    public TimerText timerTextObject;
    private float gameTime;
    private int gameSeconds;

    public void Start()
    {
        gameTime = 0;
        gameSeconds = 15;
    }

    public void Update()
    {
        gameTime += Time.deltaTime;
        if (gameTime > 1.0f)
        {
            gameTime -= 1.0f;
            gameSeconds--;
            timerTextObject.updateTimer(gameSeconds / 60, gameSeconds % 60);
        }

    }
}
