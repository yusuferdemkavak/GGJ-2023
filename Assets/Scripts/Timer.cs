using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    


public class Timer : MonoBehaviour
{
    public GameObject lightning;

    public GameObject ui;

    public int minutesLeft = 0;
    public int secondsLeft = 10;

    public Text timerText;

    void Start()
    {
        StartCoroutine(TimerStart());
    }

    void Update()
    {
        timerText.text = minutesLeft.ToString("00") + ":" + secondsLeft.ToString("00");

        if (minutesLeft <= 0 && secondsLeft <= 0)
        {
            ui.GetComponent<UIManager>().didWon = false;
            StartCoroutine(lightning.GetComponent<Lightning>().LightningFlash());
        }
    }

    public IEnumerator TimerStart()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            secondsLeft -= 1;
            if (secondsLeft <= 0)
            {
                if (minutesLeft <= 0)
                {
                    minutesLeft = 0;
                    secondsLeft = 0;
                    StopCoroutine(TimerStart());
                }
                else
                {
                    minutesLeft -= 1;
                    secondsLeft = 59;
                }
            }
        }
    }
}
