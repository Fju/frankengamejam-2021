using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEvent : MonoBehaviour
{
    private int time;

    public event EventHandler<OnTimeChangedArgs> OnTimeChanged;

    public class OnTimeChangedArgs : EventArgs
    {
        public int Time;
    }

    public void ScoreChanged()
    {
        OnTimeChanged?.Invoke(this, new OnTimeChangedArgs { Time = time });
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
