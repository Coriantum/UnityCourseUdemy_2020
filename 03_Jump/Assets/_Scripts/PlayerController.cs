using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    private const string SPEED_MULTIPLIER = "Speed multiplier";
    private const string JUMP_TRIGGER = "Jump_trig";
    private const string SPEED_F = "Speed_f";
    private const string DEATH_B = "Death_b";
    private const string DEATH_TYPE_INT = "DeathType_int";

    public float jumpForce;
    private Rigidbody playerRb;
    public float gravityMultiplier;
    public ParticleSystem explosion, dirtSplatter;
    public AudioClip jumpSound, crashSound;
    private AudioSource _audioSource;
    [Range(0,1)]
    public float audioVolume = 1;
    private float speedMultiplier= 1;

    private bool isGrounded = true;

    private bool _gameOver= false;
    public bool GameOver{
        get => _gameOver;
    }

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity = gravityMultiplier * new Vector3(0f ,9.81f ,0f);
        _animator = GetComponent<Animator>();
        _animator.SetFloat(SPEED_F, 1);
        _audioSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        speedMultiplier+= Time.deltaTime / 10;
        _animator.SetFloat(SPEED_MULTIPLIER, 1+ speedMultiplier);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && ! GameOver){
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // F = m*a
            isGrounded = false;
            _animator.SetTrigger(JUMP_TRIGGER);

            dirtSplatter.Stop();
            _audioSource.PlayOneShot(jumpSound, audioVolume);

        }
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground") && ! GameOver ){
            isGrounded = true;
            dirtSplatter.Play();
        }
        
        if(other.gameObject.CompareTag("Obstacle")){
            _gameOver = true;
            Debug.Log("Game Over");
            _animator.SetBool(DEATH_B, true);
            _animator.SetInteger(DEATH_TYPE_INT, Random.Range(1,3));
            explosion.Play();
            dirtSplatter.Stop();
            _audioSource.PlayOneShot(crashSound, audioVolume);
            Invoke("RestartGame", 5f);
        }
        
    }


    private void RestartGame(){
        speedMultiplier = 1;
        SceneManager.LoadSceneAsync("Prototype 3", LoadSceneMode.Single);
    }
}
