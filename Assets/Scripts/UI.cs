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

    public PostIt postItReference;
    public GameObject contentContainer;

    public void Start()
    {
        gameTime = 0;
        gameSeconds = 30;

        for (int i = 0; i < 5; ++i)
        {
            PostIt obj = Instantiate(postItReference, contentContainer.transform);
            obj.age = 10.0f;
            obj.fruits = new List<string>() { "Tomaten", "Gurke", "Karotten" };
        } 
        
    }

    public void Update()
    {
        gameTime += Time.deltaTime;
        if (gameTime > 1.0f)
        {
            gameTime -= 1.0f;
            if (gameSeconds > 0) gameSeconds--;
            timerTextObject.updateTimer(gameSeconds / 60, gameSeconds % 60);
        }

    }
}
