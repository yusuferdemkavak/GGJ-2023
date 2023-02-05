using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Movement movement; 

    public bool isBucketFull;
    public int fruitAmount;

    void Start()
    {
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        
    }
}
