using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;

    public int enemyCount;
    public int enemyWave= 1;

    public GameObject powerUpPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(enemyWave);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount= GameObject.FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0){
            enemyWave++;
            SpawnEnemyWave(enemyWave);

            int numberOfPowerUps = Random.Range(0,3);
            for(int i= 0; i < numberOfPowerUps; i++){
                Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
            }
        }
    }
    
    /// <summary>
    /// Genera posicion aleaoria
    /// </summary>
    /// <returns> Devuelve una posicion aleatoria </returns>
    private Vector3 GenerateSpawnPosition(){
        float spawnPosX= Random.Range(-spawnRange,spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX,0,spawnPosZ);
        return spawnPos;
    }

    /// <summary>
    /// Metodo que genera un numero determinado de enemigos en pantalla
    /// </summary>
    private void SpawnEnemyWave(int numberOfEnemies){
        for(int i= 0; i<numberOfEnemies; i++){
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    
}
