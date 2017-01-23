using UnityEngine;
using System.Collections;

public class JoyStick : MonoBehaviour
{


    public Rigidbody2D rB;
    public int moveSpeed;
    private Vector3 dir, findZRotation, WorldPos;
    private float dotProd;
    // Use this for initialization
    void Start()
    {
        Camera camera = GetComponent<Camera>();
        WorldPos = camera.ScreenToWorldPoint();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 dir = WorldPos - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //transform.LookAt(new Vector3(0,0,dotProd));
        //transform.Rotate(new Vector3(0, 0, dotProd));
        Debug.Log(dotProd);

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
            if(rB.velocity != Vector2.zero)
                rB.AddForce(-rB.velocity * moveSpeed);
        }
    }
}
/*
        if (isButton)
        {

        }
        else
        {
            if (leftJoystick)
            {
                Debug.Log("IM HERE AND WORKING");
                Vector2 inputDirection = Vector2.zero;
                inputDirection.x = Input.GetAxis("leftJoyStickHorizontal");
                inputDirection.y = Input.GetAxis("leftJoyStickVertical");
                movePos = new Vector2(inputDirection.x, inputDirection.y);
                //transform.Translate(Vector2.right * Time.deltaTime);
                rB.AddForce(movePos*1);
            }
        }

    */