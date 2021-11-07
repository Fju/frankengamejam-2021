using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostIt : MonoBehaviour
{
    public OrderLine orderLineReference;
    public GameObject verticalLayoutObject;
    public ProgressBar progressBarObject;

    public float age;
    public List<int> quantities;

    private float maxAge;
 
    public void Start()
    {
        // save start age
        maxAge = age;

        // set height according to the count of items in the fruits List
        int height = 44;
        if (quantities.Count > 0)
        {
            height += 8 + 30 * quantities.Count;
        }
        this.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);

        foreach (int quantity in quantities)
        {
            OrderLine newOrderLine = Instantiate(orderLineReference, verticalLayoutObject.transform);
            newOrderLine.quantity = quantity;
            //newOrderLine.fruit = fruit;
        }
        progressBarObject.setProgress(1.0f);
    }

    public void Update()
    {
        age -= Time.deltaTime;
        progressBarObject.setProgress(age / maxAge);

        if (age <= 0f)
        {
            OnOrderExpiredEvent?.Invoke(this, null);
            Destroy(gameObject);
        }
    }

    public static event EventHandler OnOrderExpiredEvent;
    
}
