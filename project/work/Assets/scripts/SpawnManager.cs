using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{ 
    public GameObject enemyprefab;
    public GameObject Powerupprefab;
    private GameManager gameManager;
    private float posX = 10;
    private float startDelay = 1;
    private float SpawnInterval = 1.5f;
    private float startPower = 10;
    private float PowerInterval = 20.0f;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        InvokeRepeating("SpawnRandomEnemy", startDelay, SpawnInterval);
        InvokeRepeating("SpawnPowerup", startPower, PowerInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomEnemy()
    {
        if (gameManager.isGameActive)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-posX, posX), 4f, 0f);

            Instantiate(enemyprefab, spawnPos, enemyprefab.transform.rotation);
        }
    }
    void SpawnPowerup()
    {
        if (gameManager.isGameActive)
        {
            Vector3 PowerPos = new Vector3(Random.Range(-posX, posX), 4f, 0f);

            Instantiate(Powerupprefab, PowerPos, Powerupprefab.transform.rotation);
        }
    }
}
