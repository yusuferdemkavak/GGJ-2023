using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    public GameObject player;

    public bool doesHaveFruit;
    public bool canPickupFruit;

    public GameObject bushwithFruit;
    public GameObject bushwithoutFruit;

    void Start()
    {
        doesHaveFruit = true;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && canPickupFruit)
        {
                player.GetComponent<Inventory>().fruitAmount += 1;
                doesHaveFruit = false;
                StartCoroutine(GrowFruit());
        }

        if (doesHaveFruit)
        {
            bushwithFruit.SetActive(true);
            bushwithoutFruit.SetActive(false);
        }
        else
        {
            bushwithFruit.SetActive(false);
            bushwithoutFruit.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.tag == "Player" && doesHaveFruit)
            {
                canPickupFruit = true;
            }  
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canPickupFruit = false;
        }
    }

    public IEnumerator GrowFruit()
    {
        yield return new WaitForSeconds(5);
        doesHaveFruit = true;
    }
}
