using UnityEngine;
using System.Collections;

public class sheepController : MonoBehaviour {
    
//    private Vector2 targetLoc;
//    public float maxDistance = 5, stillRange, speed;

    public static Vector2 startPos, randomSpot;
    public int speed, circleSize, waitMin, waitMax;
    private bool waiting;
    private float waitingTime;
    // Use this for initialization
    void Start ()
    {
        waiting = true;
        startPos = transform.position;
        //The random spot is set 5 units away from it's initial placement position.
        randomSpot = startPos + (Random.insideUnitCircle * circleSize);
        waitingTime = Random.Range(waitMin, waitMax);
        Debug.Log("First WaitingTime: " + waitingTime);
    }
	
	// Update is called once per frame
	void Update ()
    {
        moveSheep();
        StartCoroutine(sittingStill(waitingTime));
        
    }

    IEnumerator sittingStill(float XwaitingTime)
    {
        if (waiting)
        {
            while(XwaitingTime >= 0)
            {
                waiting = false;
                XwaitingTime -= ((int)Time.deltaTime + 1);
                waitingTime = XwaitingTime;
                Debug.Log("WaitingTime: " + XwaitingTime);
                yield return new WaitForSeconds(1);
            }
        }
    }
    void moveSheep()
    {
        if (waitingTime <= 0)
        {
            Debug.Log("Do I enter this logic?");
            //moveSheep();
            if (transform.position != new Vector3(randomSpot.x, randomSpot.y))
            {
                Debug.Log("I Should be moving?");
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
/*

            Vector2 randLoc = Random.insideUnitCircle * maxDistance;

        if (this.transform.position != new Vector3(randLoc.x, randLoc.y))
        {
            this.transform.position = Vector2.MoveTowards(transform.position, randLoc, speed * Time.deltaTime);
        }
        else
            randLoc = (Random.insideUnitCircle * maxDistance) + new Vector2(this.transform.position.x, this.transform.position.y);

        //while (new Vector2(this.transform.position.x, this.transform.position.y) != randLoc)
        //{
        //    Debug.Log("CHECKING");
        //    //this.transform.Translate(randLoc * Time.deltaTime);
        //    this.transform.position = Vector2.MoveTowards(this.transform.position, randLoc, maxDistance);
        //}
        //randLoc = Random.insideUnitCircle * maxDistance;

        //stillRange = Random.Range(0, 100);
        //if (stillRange > 50)
        //{
        //    float wait = Random.Range(1, 15);
        //    StartCoroutine(sittingStill(wait));
        //}
_________________________________________________________________________________

	public static Vector2 startPos, randomSpot;
	public int speed, circleSize;
	private Vector2 currentPos;
	
	// Use this for initialization
	void Start () 
	{
		startPos = transform.position;
		
		//The random spot is set 5 units away from it's initial placement position.
		randomSpot = startPos + (Random.insideUnitCircle * circleSize);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//If the bug's current position != the random position, it will continue to move in that direction. 
		//otherwise, it will select a new, random position from it's original placement point.
		if(transform.position != new Vector3(randomSpot.x, randomSpot.y))
		{
			transform.position = Vector3.MoveTowards(transform.position, randomSpot, speed * Time.deltaTime);
		}
		else
			randomSpot = startPos + (Random.insideUnitCircle * circleSize);

_____________________________________________________________________________________________    


*/
