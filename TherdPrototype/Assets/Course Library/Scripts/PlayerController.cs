using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float gravityModifier = 1f;
    private Rigidbody playerRb;

    public bool gameOver = false;
    private Animator playerAnimator;
    private bool isOnGround = true;
    public ParticleSystem explosionParticleSyste;
    public ParticleSystem dirtyParticleSystem;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        playerAnimator = GetComponent<Animator>();
        playerAudioSource  = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(new Vector3(0, 1, 0) * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            dirtyParticleSystem.Stop();
            playerAudioSource.PlayOneShot(jumpSound);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            if (!gameOver)
                dirtyParticleSystem.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game over");
            playerAnimator.SetInteger("DeathType_int", 1);
            playerAnimator.SetBool("Death_b", true);
            explosionParticleSyste.Play();
            dirtyParticleSystem.Stop();
            playerAudioSource.PlayOneShot(crashSound);
        }
    }
}
