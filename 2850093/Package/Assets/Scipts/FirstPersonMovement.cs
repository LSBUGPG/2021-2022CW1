using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;

    // Update is called once per frame
    void Update()
    {
        //Using the character controller component, Unity has already given us directional controls with W,A,S,D being used for +1 and -1 on their respective X and Y axis.

        float x = Input.GetAxis("Horizontal");

        float z = Input.GetAxis("Vertical");

        //Allows the player to move locally 'forward'
        Vector3 move = transform.right * x + transform.forward * z;

        //takes the above code and adds out public speed in case we want to change the movement speed stat
        controller.Move(move * speed * Time.deltaTime);
    }
}
