using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private float time = 0;
    private bool halfSecoundRendom = false;

    public float waterNeedEventPropability = 0;
    public float growDurationFirstPhase = 0;
    public float growDurationFinish = 0;

    void Start()
    {
        TimeEvents.OnTimeChanged += TimeUpdate;
    }


    private void TimeUpdate(object sender, TimeEvents.OnTimeChangedArgs e)
    {
        time += e.DeltaTime;
    }

    public enum PlantType
    {
        Carrot,
        Potato
    }
}
