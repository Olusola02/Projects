using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    private float speed = 20.0f;
    private float TurnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
   
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // moves the vehicle forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime*speed * forwardInput);
        //Rotates the car based on horizontal input
        transform.Rotate(Vector3.up, Time.deltaTime * TurnSpeed * horizontalInput);
    }
}
