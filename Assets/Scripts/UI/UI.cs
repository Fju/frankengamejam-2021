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
        gameSeconds = 5*60;

        RootObject.OnTruckEvent += OnTruckEvent;
    }

    public void OnTruckEvent(object sender, RootObject.OnTruckEventArgs args)
    {
        PostIt obj = Instantiate(postItReference, contentContainer.transform);
        obj.age = args.nextEvent + 2;
        obj.fruits = new List<string>() { "Tomaten" };
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
