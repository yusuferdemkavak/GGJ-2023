using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public GameObject bucket;
    public GameObject fruit;
    public GameObject pauseMenu;
    public GameObject Inventory;
    public GameObject Timer;
    public GameObject Settings;
    public GameObject Credits; 
    public GameObject MainMenu;
    public GameObject gameOverText;
    public GameObject winningText;
    public GameObject losingText;


    public GameObject emptyBucket;
    public GameObject fullBucket;
    public Text fruitAmountText;

    public bool didWon;

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
            Time.timeScale = 0;
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
        pauseMenu.SetActive(false);
        Inventory.SetActive(true);
        Timer.SetActive(true);
        Time.timeScale = 1;
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene(1);
    } 

    public void OnClickSettings()
    {
        Settings.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void OnClickCredits()
    {
        Credits.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void OnClickBackInSettings()
    {
        Settings.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void OnClickBackInCredits()
    {
        Credits.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);

        if(didWon == true)
        {
            losingText.SetActive(false);
        }
        else if(didWon == false)
        {
            winningText.SetActive(false);
        }
    }
}
