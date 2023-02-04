using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    public GameObject monster;
    public GameObject monsterPrefab;
    public GameObject player;

    public float monsterSpeed = 0.02f;
    public float distance;

    public bool isChasing;
    public bool isAlive;

    public int randomSpawnPoint;

    void Start()
    {
        isAlive = false;
        StartCoroutine(SpawnMonster());
    }

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, monster.transform.position);

        if (isAlive == true)
        {
            monster.transform.position = Vector2.MoveTowards(monster.transform.position, player.transform.position, monsterSpeed);
        }

        if (distance <= 8 && distance > 6)
        {
            monsterSpeed = 0.02f;
            isChasing = true;
        }
        else if (distance <= 6 && distance > 3)
        {
            monsterSpeed = 0.035f;
        }
        else if (distance <= 3)
        {
            monsterSpeed = 0.045f;
        }
        
        if(distance >= 10 && isChasing == true)
        {
            isChasing = false;
            isAlive = false;
            monster.SetActive(false);
            StartCoroutine(SpawnMonster());
        }  
    }

    public IEnumerator SpawnMonster()
    {
        yield return new WaitForSeconds(5);

        isChasing = false;
        monsterSpeed = 0.02f;
        randomSpawnPoint = Random.Range(1, 3);

        if (randomSpawnPoint == 1)
        {
            monster.transform.position = spawnPoint1.transform.position;
            monster.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (randomSpawnPoint == 2)
        {
            monster.transform.position = spawnPoint2.transform.position;
            monster.transform.localScale = new Vector3(-1, 1, 1);
        }

        monster.SetActive(true);
        isAlive = true;
    }
    
}
