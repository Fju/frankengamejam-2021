using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck_Mover : MonoBehaviour
{
    [SerializeField] int Speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 4)
        {
            transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
        }
    }
}
