using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public GameObject bucket;
    public GameObject fruit;
    public GameObject pauseMenu;
    public GameObject Inventory;
    public GameObject Timer;

    public GameObject emptyBucket;
    public GameObject fullBucket;
    public Text fruitAmountText;

    public int slotNumber = 0;

    void Start()
    {
        emptyBucket.SetActive(false);
        fullBucket.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && slotNumber == 1)
        {
            fruit.SetActive(true);
            bucket.SetActive(false);
            slotNumber = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && slotNumber == 0)
        {
            bucket.SetActive(true);
            fruit.SetActive(false);
            slotNumber = 1;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Inventory.SetActive(false);
            Timer.SetActive(false);
        }

        fruitAmountText.text = player.GetComponent<Inventory>().fruitAmount.ToString();

        if (player.GetComponent<Inventory>().isBucketFull == true)
        {
            emptyBucket.SetActive(false);
            fullBucket.SetActive(true);
        }
        else if (player.GetComponent<Inventory>().isBucketFull == false)
        {
            emptyBucket.SetActive(true);
            fullBucket.SetActive(false);
        }
    }

    public void OnClickResume()
    {
        
    }
}
