using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sea : MonoBehaviour
{
    public GameObject player;

    public bool canPickupWater;


    void Start()
    {
        canPickupWater = false;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && canPickupWater)
        {
            player.GetComponent<Inventory>().isBucketFull = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.tag == "Player" && player.GetComponent<Inventory>().isBucketFull == false)
            {
                canPickupWater = true;
            } 
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canPickupWater = false;
        }
    }
}
