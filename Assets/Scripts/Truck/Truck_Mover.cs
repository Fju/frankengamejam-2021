using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck_Mover : MonoBehaviour
{
    [SerializeField] int Speed;
    bool StartTruck;


    // Start is called before the first frame update
    public void Start()
    {
        RootObject.OnTruckEvent += OnTruckEvent;
    }

    public void OnTruckEvent(object sender, RootObject.OnTruckEventArgs args)
    {
        StartTruck = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 4 && StartTruck)
        {
            transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
        }
    }
}
