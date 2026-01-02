using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float gravityModifier = 1f;
    public bool isOnGround;
    public bool gameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip crashSound;
    public AudioClip jumpSound;
    private AudioSource _audioSource;
    private Animator _playerAnim;
    private Rigidbody _playerRb;
    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _playerAnim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        
        Physics.gravity *= gravityModifier;
        isOnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            _audioSource.PlayOneShot(jumpSound,1.0f);
            _playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround = false;
            _playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        { 
            _audioSource.PlayOneShot(crashSound,1.0f);
            dirtParticle.Stop();
            explosionParticle.Play();
            gameOver = true; 
            Debug.Log("Game Over");
            _playerAnim.SetInteger("DeathType_int",1);
            _playerAnim.SetBool("Death_b",true);
        }
    }
}
