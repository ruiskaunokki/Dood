using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    GameObject enemyObject;
    public float timeToSpawn;
    float timer;

    void Start() 
    {
        enemyObject = Instantiate(enemy);
        enemyObject.transform.position = transform.position;
        timer = timeToSpawn;
    }

    void Update() 
    {
        if ((enemyObject == null) && (timer == 0))
        {
            enemyObject = Instantiate(enemy);
            enemyObject.transform.position = transform.position;
            timer = timeToSpawn;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
