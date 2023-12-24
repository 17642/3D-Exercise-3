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
        //playerRb.AddForce(Vector3.up * 1000);//게임이 시작할 때 플레이어가 하늘로 날아감
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);//스페이스바를 누르면 하늘로 날아감.
            isOnGround = false;//땅이랑은 닿고 있지 않다고 판단,
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true; // 무언가랑 닿고 있으면 Ground에 닿고 있는 것으로 판단한다.
    }
}
