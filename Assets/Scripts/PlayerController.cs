using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRb;

    public float jumpForce;
    public float gravityModifier;

    public bool isOnGround = true;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //playerRb.AddForce(Vector3.up * 1000);//������ ������ �� �÷��̾ �ϴ÷� ���ư�
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);//�����̽��ٸ� ������ �ϴ÷� ���ư�.
            isOnGround = false;//���̶��� ��� ���� �ʴٰ� �Ǵ�,
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true; // ���𰡶� ��� ������ Ground�� ��� �ִ� ������ �Ǵ��Ѵ�.
    }
}