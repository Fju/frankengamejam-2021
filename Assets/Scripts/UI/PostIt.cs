using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostIt : MonoBehaviour
{
    public float createdAt;
    public List<string> fruits;

    public void Start()
    {
        createdAt = 0;
        Debug.Log(string.Format("Created posit: {0}", createdAt));
    }

    public void setContent(string test)
    {
        Debug.Log(test);
    }

}
