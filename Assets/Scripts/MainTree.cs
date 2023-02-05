using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTree : MonoBehaviour
{
    public GameObject treePhase1;
    public GameObject treePhase2;
    public GameObject treePhase3;
    public GameObject treePhase4;
    public GameObject player;
    public GameObject ui;
    public GameObject lightning;
    public bool canWater;


    public int treePhase = 1;
    public int timesWatered = 0;


    void Start()
    {
        treePhase1.SetActive(true);
        treePhase2.SetActive(false);
        treePhase3.SetActive(false);
        treePhase4.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && player.GetComponent<Inventory>().isBucketFull == true && ui.GetComponent<UIManager>().slotNumber == 1 && canWater == true)
        {
            player.GetComponent<Inventory>().isBucketFull = false;
            timesWatered += 1;
        }

        if (timesWatered == 1)
        {
            treePhase = 2;
        }
        else if (timesWatered == 4)
        {
            treePhase = 3;
        }
        else if (timesWatered == 9)
        {
            treePhase = 4;
            timesWatered = 0;
        }

        if (treePhase == 2)
        {
            treePhase1.SetActive(false);
            treePhase2.SetActive(true);
        }
        else if (treePhase == 3)
        {
            treePhase2.SetActive(false);
            treePhase3.SetActive(true);
        }
        else if (treePhase == 4)
        {
            treePhase3.SetActive(false);
            treePhase4.SetActive(true);
            ui.GetComponent<UIManager>().didWon = true;
            StartCoroutine(lightning.GetComponent<Lightning>().LightningFlash());
            treePhase = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canWater = true;
        }  
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canWater = false;
        }
    }

}
