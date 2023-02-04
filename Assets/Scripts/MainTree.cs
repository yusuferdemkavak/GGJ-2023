using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTree : MonoBehaviour
{
    public GameObject treePhase1;
    public GameObject treePhase2;
    public GameObject treePhase3;
    public GameObject treePhase4;

    public int treePhase = 1;


    void Start()
    {
        treePhase1.SetActive(true);
        treePhase2.SetActive(false);
        treePhase3.SetActive(false);
        treePhase4.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && treePhase == 1)
        {
            treePhase1.SetActive(false);
            treePhase2.SetActive(true);
            treePhase = 2;
        }
        else if (Input.GetKeyDown(KeyCode.E) && treePhase == 2)
        {
            treePhase2.SetActive(false);
            treePhase3.SetActive(true);
            treePhase = 3;
        }
        else if (Input.GetKeyDown(KeyCode.E) && treePhase == 3)
        {
            treePhase3.SetActive(false);
            treePhase4.SetActive(true);
            treePhase = 4;
        }
    }
}
