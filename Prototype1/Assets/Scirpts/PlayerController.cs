using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed = 20.0f;
    private float _turnSpeed = 15.0f;
    private float _horizontalInput;
    private float _verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        //Move the vehicle forward
        transform.Translate(Vector3.forward * (Time.deltaTime * _speed*_verticalInput));
        // Rotates the car based on horizontal input
        transform.Rotate(Vector3.up, (Time.deltaTime * _turnSpeed*_horizontalInput));
    }
}
