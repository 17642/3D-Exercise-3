using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float leftBound = -15;
    private float speed = 30;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();//Player��� �̸��� ���� ������Ʈ�� ã�Ƽ� ������Ʈ�� �����´�.
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)//���� ���� ���°� �ƴϸ�
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);//�������� ��� �̵�
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);//�±װ� Obstacle�̰� leftBound���� �ָ� ���ư����� ������Ʈ �ı�
        }
    }
}
