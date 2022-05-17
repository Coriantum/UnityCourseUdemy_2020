using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody _rigidbody;
    private float minForce = 12,
        maxForce =16,
        maxTorque = 10,
        xRange = 4,
        ySpawnForce = -6;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPosition(); // z = 0
    }

    /// <summary>
    /// Genera un vector aleatorio(3D)
    /// </summary>
    /// <returns> Fuerza aleatoria para arriba</returns>
    private Vector3 RandomForce(){
        return Vector3.up * Random.Range(minForce,maxForce);
    }


    /// <summary>
    /// Genera un numero aleatorio
    /// </summary>
    /// <returns> Valor aleatorio entre -maxTorque y maxTorque</returns>
    private float RandomTorque(){
        return Random.Range(-maxTorque,maxTorque);
    }


    /// <summary>
    /// Genera una posicion aleatoria
    /// </summary>
    /// <returns> Posicion aleatoria en 3D,con coordenada z = 0</returns>
    private Vector3 RandomSpawnPosition(){
        return new Vector3(Random.Range(-xRange, xRange), ySpawnForce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
