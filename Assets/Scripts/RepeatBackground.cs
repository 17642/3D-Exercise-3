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
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;//�ݺ� ���� ���� -> ����� 2���� �̹����� ��ģ ���̹Ƿ� ���� ���� �������� ó������ �ٽ� ����
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <startPos.x - repeatWidth)
        {
            transform.position = startPos;//����� ��� ���� �̵��ϸ� ���� ��ġ�� ���ƿ�
        }
    }
}
