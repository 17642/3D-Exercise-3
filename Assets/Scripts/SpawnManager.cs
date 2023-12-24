using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float startDelay = 2;
    private float repeatRate = 2;

    public GameObject obstaclePrefab;
    private Vector3 spawnPos= new Vector3(25,0,0);
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);//반복적으로 "SpawnObstacle" 수행
        //Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);//시작 시 장애물 1개 생성
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
