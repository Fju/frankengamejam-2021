using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck_Mover : MonoBehaviour
{
    [SerializeField] int Speed;
    public int counter;
    public bool LeaveTruck;

    // Start is called before the first frame update
    public void Start()
    {
        RootObject.OnTruckEnterEvent += OnTruckEnterEvent;
        RootObject.OnTruckLeaveEvent += OnTruckLeaveEvent;
    }

    public void OnTruckEnterEvent(object sender, EventArgs args)
    {
        counter++;
    }

    public void OnTruckLeaveEvent(object sender, EventArgs args)
    {
        counter--;
        LeaveTruck = true;
    }

    // Update is called once per frame
    public void Update()
    {
        if (!LeaveTruck && counter > 0)
        {
            if (transform.position.x >= 10f)
            {
                transform.position += new Vector3(-Speed * Time.deltaTime, 0, 0);
            }
        } else if (LeaveTruck)
        {
            if (transform.position.x <= 15f)
            {
                transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
            } else
            {
                LeaveTruck = false;
            }
        }
    }
}
