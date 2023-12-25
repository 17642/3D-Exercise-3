using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRb;
    private Animator amim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioSource playerAudio;

    public float jumpForce;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        amim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        //playerRb.AddForce(Vector3.up * 1000);//게임이 시작할 때 플레이어가 하늘로 날아감
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& isOnGround&&!gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);//스페이스바를 누르면 하늘로 날아감.
            isOnGround = false;//땅이랑은 닿고 있지 않다고 판단,
            amim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isOnGround = true; // Ground와 닿으면 isOnGround = true
            dirtParticle.Play();
        }
        if (collision.transform.CompareTag("Obstacle"))
        {
            gameOver = true; //장애물에 닿으면 게임 오버
            Debug.Log("GAME OVER!");
            amim.SetBool("Death_b", true);
            amim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
