using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    public float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;//반복 구간 길이 -> 배경이 2개의 이미지를 합친 것이므로 절반 정도 지나가면 처음부터 다시 시작
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <startPos.x - repeatWidth)
        {
            transform.position = startPos;//배경이 어느 정도 이동하면 시작 위치로 돌아옴
        }
    }
}
