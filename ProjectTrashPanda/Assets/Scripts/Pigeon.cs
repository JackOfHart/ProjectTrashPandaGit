using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : MonoBehaviour {

    public GameObject Player;
    public float Speed = 5;
    public float jumpHeight = 5;
    public float jumpDistance = 5;
    public float DistanceSpace = 1;
    public float DistanceIsJump = 7;

    private Vector3 PlayerPosition;
    private Vector3 PigeonPosition;

    private bool isJump = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

 
        PigeonPosition = transform.position;
        PlayerPosition = Player.transform.position;
        
        float Distance = Vector3.Distance(PigeonPosition, PlayerPosition);
       // print(Distance);

        if ( Distance < DistanceSpace )
        {
            isJump = true;
        }

        if (isJump == true)
        {
            PigeonJump();
        }

        if( Distance > DistanceIsJump)
        {
            isJump = false;
        }
    }

    void PigeonJump()
    {
        //bird needs to rise diagnolly and then move towards a point, then land diagnolly
        transform.position += new Vector3 (1, 1, 0) * jumpHeight * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, (transform.position += new Vector3(0.5f, 0.5f, 0)), Speed);

        transform.position = Vector3.MoveTowards(transform.position, (transform.position += new Vector3(0, 0, 5)), Speed);

        //Bird goes forward
        // transform.position += new Vector3(0f, 0f, Random.Range(1f, 0f)) * Speed * Time.deltaTime;
        //Bird goes up  


    }
   

}
