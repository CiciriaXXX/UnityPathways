using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float _timer;
    public float minSpawnInterval = 1;

    private void Start()
    {
        //初始即冷却完毕
        _timer = minSpawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        //始终增加计时器
        _timer += Time.deltaTime;
        
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_timer < minSpawnInterval) return; //使用卫语句，更简洁
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            _timer = 0;
            
        }
    }
}
