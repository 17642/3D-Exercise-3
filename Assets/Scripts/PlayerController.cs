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
        //playerRb.AddForce(Vector3.up * 1000);//������ ������ �� �÷��̾ �ϴ÷� ���ư�
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& isOnGround&&!gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);//�����̽��ٸ� ������ �ϴ÷� ���ư�.
            isOnGround = false;//���̶��� ��� ���� �ʴٰ� �Ǵ�,
            amim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isOnGround = true; // Ground�� ������ isOnGround = true
            dirtParticle.Play();
        }
        if (collision.transform.CompareTag("Obstacle"))
        {
            gameOver = true; //��ֹ��� ������ ���� ����
            Debug.Log("GAME OVER!");
            amim.SetBool("Death_b", true);
            amim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
