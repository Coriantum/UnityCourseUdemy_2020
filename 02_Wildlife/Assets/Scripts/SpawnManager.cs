using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemies;
    private int animalIndex;

    private float spawnRangeX = 14f;
    private float spawnPosZ;

    private float startDelay = 2f;
    private float spawnInterval = 1.5f; //Cada cuanto generar un enemigo


    private void Start() {
        spawnPosZ = this.transform.position.z;
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }


    // Update is called once per frame
    void Update()
    {
            
    }


    private void SpawnRandomAnimal(){
        float xRand = Random.Range(-spawnRangeX,spawnRangeX);
        Vector3 spawnPos = new Vector3(xRand, 0, spawnPosZ);


        animalIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[animalIndex], spawnPos, enemies[animalIndex].transform.rotation);
    }

}
