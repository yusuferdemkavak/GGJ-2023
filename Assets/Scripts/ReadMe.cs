using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadMe : MonoBehaviour
{
    public int pageNumber = 0;
    public bool canRead;
    public bool isReading;

    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;
    public GameObject nextPage;
    public GameObject previousPage;

    public GameObject parchment;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && canRead == true)
        {
            parchment.SetActive(true);
            isReading = true;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isReading == true)
        {
            parchment.SetActive(false);
            isReading = false;
            Time.timeScale = 1;
        }

        if (pageNumber == 0)
        {
            previousPage.SetActive(false);
            nextPage.SetActive(true);
            page1.SetActive(true);
            page2.SetActive(false);
            page3.SetActive(false);
            page4.SetActive(false);
        }
        else if (pageNumber == 1)
        {
            previousPage.SetActive(true);
            nextPage.SetActive(true);
            page1.SetActive(false);
            page2.SetActive(true);
            page3.SetActive(false);
            page4.SetActive(false);
        }
        else if (pageNumber == 2)
        {
            previousPage.SetActive(true);
            nextPage.SetActive(true);
            page1.SetActive(false);
            page2.SetActive(false);
            page3.SetActive(true);
            page4.SetActive(false);
        }
        else if (pageNumber == 3)
        {
            previousPage.SetActive(true);
            nextPage.SetActive(false);
            page1.SetActive(false);
            page2.SetActive(false);
            page3.SetActive(false);
            page4.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.tag == "Player")
            {
                canRead = true;
            }  
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canRead = false;
        }
    }

    public void OnClickNextPage()
    {
        pageNumber += 1;
    }

    public void OnClickPreviousPage()
    {
        pageNumber -= 1;
    }
}
