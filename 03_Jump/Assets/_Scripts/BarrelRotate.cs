using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRotate : MonoBehaviour
{
   
    private PlayerController playerController;

    [SerializeField]
    private float rotateSpeed = 60;

    [SerializeField]
    private float translateSpeed =1;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if(! playerController.GameOver){
            //transform.Translate(Vector3.left * translateSpeed * Time.deltaTime); No funcionaría,no queremos una translacion de vectores

            transform.localPosition += Vector3.left *translateSpeed *Time.deltaTime; // Necesitamos cambiar la posicion de coordenadas(Local)

            //Rotamos
            transform.Rotate(Vector3.up * rotateSpeed* Time.deltaTime);
        }
    }
}
