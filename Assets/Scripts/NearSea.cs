using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearSea : MonoBehaviour
{
    public GameObject monsterAI;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            monsterAI.GetComponent<MonsterAI>().isNearSea = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            monsterAI.GetComponent<MonsterAI>().isNearSea = false;
            StartCoroutine(monsterAI.GetComponent<MonsterAI>().SpawnMonster());
        }
    }
}
