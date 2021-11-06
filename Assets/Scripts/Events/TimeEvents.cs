using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEvents : MonoBehaviour
{
    private float time;

    public void Update()
    {
        time += Time.deltaTime;
        OnTimeChanged?.Invoke(this, new OnTimeChangedArgs { Time = time, DeltaTime = Time.deltaTime });
    }

    public static event EventHandler<OnTimeChangedArgs> OnTimeChanged;

    public class OnTimeChangedArgs : EventArgs
    {
        public float Time;
        public float DeltaTime;
    }

    /*
    void Start() 
    {
        ScoreEvents.OnScoreChanged += ScoreUpdate
    }
    
    void ScoreUpdate(object sender, ScoreEvents.OnScoreChangedArgs e){
        ui.Text = e.Score 
    }
     */
}
