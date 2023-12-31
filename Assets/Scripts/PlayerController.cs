using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    public Camera primaryCamera;
    public Camera secondaryCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // uses Input Manager to assign what inputs actually affect
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // Actually turns the vehicle
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        // Causes the vehicle to slide left or right upon input
        // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);

        if(Input.GetKeyDown(KeyCode.V)) {
            if(primaryCamera.enabled == true) {
                primaryCamera.enabled = false;
                secondaryCamera.enabled = true;
            } else if(secondaryCamera.enabled == true) {
                secondaryCamera.enabled = false;
                primaryCamera.enabled = true;
            }
        }
    }
}
