using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEvents : MonoBehaviour
{
    private int score;
    
    public event EventHandler<OnScoreChangedArgs> OnScoreChanged;

    public class OnScoreChangedArgs : EventArgs
    {
        public int Score;
    }

    public void ScoreChanged()
    {
        OnScoreChanged?.Invoke(this, new OnScoreChangedArgs { Score = score });
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
