using UnityEngine;
using System.Collections;

public class sheepController : MonoBehaviour {
    
    public static Vector2 startPos, randomSpot;
    public int speed, circleSize, waitMin, waitMax;
    private bool waiting;
    private float waitingTime;

    void Start ()
    {
        waiting = true;
        startPos = transform.position;
        //The random spot is set 5 units away from it's initial placement position.
        randomSpot = startPos + (Random.insideUnitCircle * circleSize);
        waitingTime = Random.Range(waitMin, waitMax);
    }
	
	void Update ()
    {
        // TL;DR : I want to wait a random amount of time between actually moving,
        //         and waiting around.
        moveSheep();
        StartCoroutine(sittingStill(waitingTime));
    }

    IEnumerator sittingStill(float XwaitingTime)
    {
        // This makes sure to check if if I'm waiting or moving, then
        // it will count down realtime
        if (waiting)
        {
            while(XwaitingTime >= 0)
            {
                waiting = false;
                XwaitingTime -= ((int)Time.deltaTime + 1);
                waitingTime = XwaitingTime;
                yield return new WaitForSeconds(1);
            }
        }
    }
    void moveSheep()
    {
        // if I'm not waiting anymore, I'll check if my current position is my randomly selected,
        // and if it's not, i'll move in that direction until it is. Otherwise, I'll pick a new
        // spot, and wait a certain amount of time before I start walking to it again.w
        if (waitingTime <= 0)
        {
            if (transform.position != new Vector3(randomSpot.x, randomSpot.y))
            {
                transform.position = Vector3.MoveTowards(transform.position, randomSpot, speed * Time.deltaTime);
            }
            else
            {
                randomSpot = randomSpot + (Random.insideUnitCircle * circleSize);
                waiting = true;
                waitingTime = Random.Range(waitMin, waitMax);
            }
        }
    }
}