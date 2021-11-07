using System;
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

        RootObject.OnOrderCreatedEvent += OnOrderCreated;
    }

    public void OnOrderCreated(object sender, RootObject.OrderCreatedEventArgs args)
    {
        PostIt postIt = Instantiate(postItReference, contentContainer.transform);
        postIt.age = args.nextOrder + 5;
        postIt.quantities = new List<int> { args.quantity };
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
