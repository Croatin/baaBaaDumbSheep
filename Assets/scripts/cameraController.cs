using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {

    private GameObject[] players;
    private Camera[] cameras;
    private Vector3 offset;
	void Start ()
    {
        offset = new Vector3(0, 0, -20);
        players = GameObject.FindGameObjectsWithTag("player");
        cameras = GameObject.FindObjectsOfType<Camera>();
        if(players.Length == 1)
        {
            cameras[0].rect = new Rect(0, 0, 1, 1);
            Debug.Log(cameras[0].rect);
        }
        if (players.Length == 2)
        {
            cameras[0].rect = new Rect(0, 0.5F, 1, 1);
            cameras[1].rect = new Rect(0, -0.5F, 1, 1);
            Debug.Log(cameras[0].rect);
        }
        if (players.Length == 3)
        {
            cameras[0].rect = new Rect(-0.5F, 0, 1, 1);
            cameras[1].rect = new Rect(0.5f, 0.5F, 1, 1);
            cameras[2].rect = new Rect(0.5f, -0.5F, 1, 1);
            Debug.Log(cameras[0].rect);
        }
        if (players.Length == 4)
        {
            cameras[0].rect = new Rect(0.5F, 0.5f, 1, 1);
            cameras[1].rect = new Rect(0.5f, -0.5F, 1, 1);
            cameras[2].rect = new Rect(-0.5f, 0.5F, 1, 1);
            cameras[3].rect = new Rect(-0.5f, -0.5F, 1, 1);
            Debug.Log(cameras[0].rect);
        }
    }
	
	void Update ()
    {
        for (int i = 0; i <= players.Length; i++)
        {
            cameras[i].transform.position = players[i].transform.position + offset;
            Debug.Log("i: " + i);
            if (i >= players.Length)
            {
                i = 0;
                break;
            }
        }
    }
}
