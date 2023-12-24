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
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();//Player라는 이름을 가진 오브젝트를 찾아서 컴포넌트를 가져온다.
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)//게임 오버 상태가 아니면
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);//왼쪽으로 계속 이동
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);//태그가 Obstacle이고 leftBound보다 멀리 나아갔으면 오브젝트 파괴
        }
    }
}
