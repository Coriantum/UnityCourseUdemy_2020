using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Range(0,100)]
    public float speed, rotateSpeed, force;
    public float jumpForce = 8f;

    public bool usePhysicsEngine;
    private float verticalInput;
    private float horizontalInput;

    public GameObject player;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        if(usePhysicsEngine){
            // Si se usa la fisica
            // Addforce sobre el rigidbody
            // AddTorque sobre el rigidbody
            rb.AddForce(Vector3.forward* Time.deltaTime*force * verticalInput);
            rb.AddTorque(Vector3.up * Time.deltaTime * force * horizontalInput);
        }else{
            // Si no se emplea la fisica
            // Translate sobre transform -> Para mover
            // Rotate sobre el Transform -> Para rotar
            transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * horizontalInput);

        }
        
        
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
