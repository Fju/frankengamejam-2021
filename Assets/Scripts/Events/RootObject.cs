using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootObject : MonoBehaviour
{
    private float time = 0;
    private float randomTime = 0;

    public float minTimeRandom;
    public float maxTimeRandom;

    void Start()
    {
        TimeEvents.OnTimeChanged += TimeUpdate;
    }
    
    private void TimeUpdate(object sender, TimeEvents.OnTimeChangedArgs e)
    {
        time += e.DeltaTime;
        
        if (time > randomTime)
        {
            randomTime = UnityEngine.Random.Range(minTimeRandom, maxTimeRandom);
            RootObject.OnTruckEvent?.Invoke(this, new OnTruckEventArgs { eventTime = time, nextEvent = randomTime });
            time = 0;
        }
    }
    
    public static event EventHandler<OnTruckEventArgs> OnTruckEvent;

    public class OnTruckEventArgs : EventArgs
    {
        public float eventTime;
        public float nextEvent;
    }
}
