using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRb;
    private Animator amim;

    public float jumpForce;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        amim = GetComponent<Animator>();
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
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isOnGround = true; // Ground�� ������ isOnGround = true
        }
        if (collision.transform.CompareTag("Obstacle"))
        {
            gameOver = true; //��ֹ��� ������ ���� ����
            Debug.Log("GAME OVER!");
            amim.SetBool("Death_b", true);
            amim.SetInteger("DeathType_int", 1);
        }
    }
}
