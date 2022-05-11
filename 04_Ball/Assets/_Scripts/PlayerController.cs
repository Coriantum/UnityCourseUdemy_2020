using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float forceMove;
    private Rigidbody _rigidbody;
    public GameObject focalPoint;
    public GameObject[] powerUpIndicators;
    private bool hasPowerUp;
    public float powerUpForce;
    private float powerUpTime = 7f;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        // Mejor usar en el futuro por seguridad
        // focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float inputForward = Input.GetAxis("Vertical");
        _rigidbody.AddForce(focalPoint.transform.forward * forceMove * inputForward);

        // Cambiamos posicion de los anillos
        foreach(GameObject indicator in powerUpIndicators){
            indicator.transform.position = this.transform.position + 0.5f * Vector3.down;

        }

    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("PowerUp")){
            hasPowerUp = true;
            Destroy(other.gameObject);
    
            // Arrancamos corrutina para duracion del poder e indicadores
            StartCoroutine(PowerUpCountdown());
            
        }

        if(other.gameObject.name.CompareTo("KillZone")==0){ // == 0 quiere decir que están en la misma posicion
            SceneManager.LoadScene("Prototype4");
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp){
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer= collision.gameObject.transform.position - this.transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerUpForce ,ForceMode.Impulse);

        }
        
    }

    IEnumerator PowerUpCountdown(){
        foreach(GameObject indicator in powerUpIndicators){
            indicator.gameObject.SetActive(true);
            yield return new WaitForSeconds(powerUpTime/powerUpIndicators.Length);
            indicator.gameObject.SetActive(false);
        }
    // Opcion 2: For
    /*
        for(int i = 0; i< powerUpIndicators.Length; i++){
            powerUpIndicators[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(powerUpTime/powerUpIndicators.Length);
            powerUpIndicators[i].gameObject.SetActive(false);
        }
    */
        hasPowerUp = false;
    }
}
