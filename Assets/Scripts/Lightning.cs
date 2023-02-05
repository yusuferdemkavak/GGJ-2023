using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lightning : MonoBehaviour
{

    public GameObject player;
    public GameObject rain;
    public GameObject mCamera;
    public GameObject inventory;
    public GameObject staminaBar;
    public GameObject winningText;
    public GameObject losingText;
    public GameObject gameOverText;
    public GameObject ui;

    public Image lightning;

    void Start()
    {
        lightning.CrossFadeAlpha(0, 0, false);
    }

    void Update()
    {
        
    }

    public IEnumerator LightningFlash()
    {
        player.SetActive(false);
        rain.SetActive(true);
        inventory.SetActive(false);
        staminaBar.SetActive(false);
        ui.GetComponent<Timer>().enabled = false;
        player.transform.position = new Vector3(0, -2, 0);
        mCamera.transform.position = new Vector3(0, 0f, -10);
        lightning.CrossFadeAlpha(1, 0, false);
        ui.GetComponent<UIManager>().GameOver();
        yield return new WaitForSeconds(0.2f);
        lightning.CrossFadeAlpha(0, 0.3f, false);
        yield return new WaitForSeconds(5);
        StartCoroutine(LightningFlash());
    }
}
