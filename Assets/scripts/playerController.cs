using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    public Rigidbody2D rB;
    public int moveSpeed;
    private float dotProd;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 localVelocity = transform.InverseTransformDirection(GetComponent<Rigidbody2D>().velocity);
        Debug.Log("Local Velocity: " + localVelocity); // attempt change to get git to commit//
        transform.Rotate(new Vector3(0, 0, localVelocity.y));

        if (Input.GetKey(KeyCode.UpArrow) ||
           Input.GetKey(KeyCode.LeftArrow) ||
           Input.GetKey(KeyCode.RightArrow) ||
           Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.UpArrow))
                rB.AddForce(Vector2.up * moveSpeed);
            if (Input.GetKey(KeyCode.LeftArrow))
                rB.AddForce(Vector2.left * moveSpeed);
            if (Input.GetKey(KeyCode.DownArrow))
                rB.AddForce(Vector2.down * moveSpeed);
            if (Input.GetKey(KeyCode.RightArrow))
                rB.AddForce(Vector2.right * moveSpeed);
        }
        else
        {
            if (rB.velocity != Vector2.zero)
                rB.AddForce(-rB.velocity * moveSpeed);
        }
    }
}