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

    public float monsterSpeed;
    public float distance;

    public bool isChasing;
    public bool isAlive;

    public int randomSpawnPoint;
    public int monsterAmount;

    void Start()
    {
        isAlive = false;
        isChasing = false;
        StartCoroutine(SpawnMonster());
    }

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, monster.transform.position);

        if (isAlive == true)
        {
            monster.transform.position = Vector2.MoveTowards(monster.transform.position, player.transform.position, monsterSpeed);
        }

        if (distance > 10)
        {
            monsterSpeed = 0.1f;
        }
        else if (distance <= 10 && distance > 8)
        {
            monsterSpeed = 0.02f;
        }
        else if (distance <= 8 && distance > 6)
        {
            monsterSpeed = 0.03f;
            isChasing = true;
        }
        else if (distance <= 6 && distance > 3)
        {
            monsterSpeed = 0.04f;
        }
        else if (distance <= 3)
        {
            monsterSpeed = 0.05f;
        }
        
        if(distance >= 10 && isChasing == true)
        {
            isChasing = false;
            isAlive = false;
            Destroy(monster);
            monsterAmount = 0;
            StartCoroutine(SpawnMonster());
        }  
    }

    public IEnumerator SpawnMonster()
    {
        yield return new WaitForSeconds(7.5f);

        isChasing = false;
        monsterSpeed = 0.02f;
        randomSpawnPoint = Random.Range(1, 3);

        if (randomSpawnPoint == 1 && monsterAmount == 0)
        {
            monster = Instantiate(monsterPrefab, spawnPoint1.transform.position, Quaternion.identity);
            monster.transform.localScale = new Vector3(1, 1, 1);
            isAlive = true;
            monsterAmount += 1;

        }
        else if (randomSpawnPoint == 2  && monsterAmount == 0)
        {
            monster = Instantiate(monsterPrefab, spawnPoint2.transform.position, Quaternion.identity);
            monster.transform.localScale = new Vector3(-1, 1, 1);
            isAlive = true;
            monsterAmount += 1;
        }
    }
}
