using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveForce;
    private GameObject player;
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - this.transform.position).normalized;
        _rigidbody.AddForce(lookDirection * moveForce, ForceMode.Force);

        if(this.transform.position.y < -10){
            Destroy(this.gameObject);
        }
    }

   
}
