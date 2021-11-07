using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrderState
{
    CREATE_ORDER, WAIT
}

public class Order
{
    public int carrotQuantity = 0;
    public int potatoeQuantity = 0;
    public float age;
}

public class RootObject : MonoBehaviour
{

    public float minTimeRandom;
    public float maxTimeRandom;

    private OrderState orderState = OrderState.CREATE_ORDER;
    private float orderStateTimer = 0;

    private List<Order> orders;

    public void Start()
    {
        //TimeEvents.OnTimeChanged += TimeUpdate;
        PostIt.OnOrderExpiredEvent += OnOrderExpired;
    }

    public void OnOrderExpired(object sender, EventArgs args)
    {
        OnTruckLeaveEvent?.Invoke(this, null);
    }

    public void Update()
    {
        if (orderState == OrderState.CREATE_ORDER)
        {
            orderStateTimer = UnityEngine.Random.Range(minTimeRandom, maxTimeRandom);
            orderState = OrderState.WAIT;

            OnTruckEnterEvent?.Invoke(this, null);

            // pick random quantity
            int qty = (int)Mathf.Floor(UnityEngine.Random.Range(1f, 5f));
            OnOrderCreatedEvent?.Invoke(this, new OrderCreatedEventArgs { quantity = qty, nextOrder = orderStateTimer });
        } else if (orderState == OrderState.WAIT)
        {
            orderStateTimer -= Time.deltaTime;
            if (orderStateTimer <= 0)
            {
                orderState = OrderState.CREATE_ORDER;
            }
        }
    }


    public static event EventHandler OnTruckEnterEvent;
    public static event EventHandler OnTruckLeaveEvent;
    public static event EventHandler<OrderCreatedEventArgs> OnOrderCreatedEvent;

    public class OrderCreatedEventArgs : EventArgs
    {
        public int quantity;
        public float nextOrder;
        // public string fruit;
    }
}
