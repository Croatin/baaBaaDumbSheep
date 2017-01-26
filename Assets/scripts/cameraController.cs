using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {

    private Rigidbody2D player;
    private GameObject playerCount;
    private Camera playerCamera;
    private Vector3 offset;
	// Use this for initialization
	void Start ()
    {
        player = gameObject.GetComponentInChildren<Rigidbody2D>();
        playerCamera = gameObject.GetComponentInChildren<Camera>();
        offset = new Vector3(0, 0, -20);
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerCamera.transform.position = player.transform.position + offset;
	}
}
