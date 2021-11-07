using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck_Mover : MonoBehaviour
{
    [SerializeField] int Speed;
    public bool StartTruck;
    public bool LeaveTruck;

    // Start is called before the first frame update
    public void Start()
    {
        RootObject.OnTruckEnterEvent += OnTruckEnterEvent;
        RootObject.OnTruckLeaveEvent += OnTruckLeaveEvent;
    }

    public void OnTruckEnterEvent(object sender, EventArgs args)
    {
        StartTruck = true;
    }

    public void OnTruckLeaveEvent(object sender, EventArgs args)
    {
        LeaveTruck = true;
    }

    // Update is called once per frame
    public void Update()
    {
        if (StartTruck && !LeaveTruck)
        {
            if (transform.position.x >= 4f)
            {
                transform.position += new Vector3(-Speed * Time.deltaTime, 0, 0);
            } else
            {
                StartTruck = false;
            }
        }
        if (LeaveTruck)
        {
            if (transform.position.x <= 10f)
            {
                transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
            } else
            {
                LeaveTruck = false;
            }
        }
    }
}
