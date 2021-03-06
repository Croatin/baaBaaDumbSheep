﻿using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
    
    public int moveSpeed;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        float movementY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float movementX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        
        player.transform.Translate(movementX, 0, movementY);
        player.GetComponent<Rigidbody>().AddTorque(transform.right * movementX);
    }
}
/*
 *         //localVelocity is used to get the Direction in the form of a vector of the player. 
        //This is used to determin the direction we're facing and rotate accordingly along the Z axis
        //I'm not 100% sure about the math that makes this work, but it does. 
        Vector3 localVelocity = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
        transform.Rotate(new Vector3(0, 0, localVelocity.y));


        //TODO: change the input verification to horizontal/vertical so that the controls can
        //easily be changed by the player in an option menu
        if (Input.GetKey(KeyCode.UpArrow) ||
           Input.GetKey(KeyCode.LeftArrow) ||
           Input.GetKey(KeyCode.RightArrow) ||
           Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.UpArrow))
                rB.AddForce(Vector3.up * moveSpeed);
            if (Input.GetKey(KeyCode.LeftArrow))
                rB.AddForce(Vector3.left * moveSpeed);
            if (Input.GetKey(KeyCode.DownArrow))
                rB.AddForce(Vector3.down * moveSpeed);
            if (Input.GetKey(KeyCode.RightArrow))
                rB.AddForce(Vector3.right * moveSpeed);
        }
        else
        {
            if (rB.velocity != Vector3.zero)
                rB.AddForce(-rB.velocity * moveSpeed);
        }
 */
