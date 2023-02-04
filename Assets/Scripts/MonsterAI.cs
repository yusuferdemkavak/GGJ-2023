using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    public GameObject monster;
    public GameObject player;

    public float monsterSpeed = 0.01f;
    public float distance;

    public bool isChasing;

    int randomSpawnPoint;

    void Start()
    {
        monster.SetActive(false);
        StartCoroutine(SpawnMonster());
    }

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, monster.transform.position);

        monster.transform.position = Vector2.MoveTowards(monster.transform.position, player.transform.position, monsterSpeed);

        if (distance <= 8 && distance > 6)
        {
            monsterSpeed = 0.02f;
            isChasing = true;
        }
        else if (distance <= 6 && distance > 3)
        {
            monsterSpeed = 0.03f;
        }
        else if (distance <= 3)
        {
            monsterSpeed = 0.04f;
        }
        
        if(distance >= 10 && isChasing == true)
        {
            isChasing = false;
            monster.SetActive(false);
            StartCoroutine(SpawnMonster());
        }  
    }

    public IEnumerator SpawnMonster()
    {
        yield return new WaitForSeconds(15);

        isChasing = false;
        randomSpawnPoint = Random.Range(1, 3);

        if (randomSpawnPoint == 1)
        {
            monster.transform.position = spawnPoint1.transform.position;
        }
        else if (randomSpawnPoint == 2)
        {
            monster.transform.position = spawnPoint2.transform.position;
        }
        
        monster.SetActive(true);
    }
}
