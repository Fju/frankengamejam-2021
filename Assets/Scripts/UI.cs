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
        gameSeconds = 15;

        for (int i = 0; i < 3; ++i)
        {
            PostIt obj = Instantiate(postItReference, contentContainer.transform);
            obj.setContent("hello");
        }
        
 
        
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
