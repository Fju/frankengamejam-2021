using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck_Mover : MonoBehaviour
{
    [SerializeField] int Speed;
    public RootObject rootObject;
    public PostIt postItReference;
    public GameObject contentContainer;
    bool GoTruck;
    // Start is called before the first frame update
    public void Start()
    {
        rootObject.OnTruckEvent += OnTruckEvent;
    }

    public void OnTruckEvent(object sender, RootObject.OnTruckEventArgs args)
    {

        PostIt obj = Instantiate(postItReference, contentContainer.transform);
        obj.age = args.nextEvent - 5;
        obj.fruits = new List<string>() { "Tomaten", "Gurke" };
        GoTruck = true;
    }
        // Update is called once per frame
        void Update()
    {
        if (transform.position.x >= 4 && GoTruck)
        {
            transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
        }
    }
}
