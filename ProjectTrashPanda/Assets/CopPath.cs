using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopPath : MonoBehaviour {

    public GameObject beacon1;
    public GameObject beacon2;

    private bool collideEver = false;
    private bool copDirection = true;
    public int copSpeed = 1;


	// Use this for initialization
	void Start () {
        
	}

    void Update ()
    {

        if(copDirection == true)
        {
            this.transform.position += Vector3.forward * copSpeed * Time.deltaTime;
        }

        if(copDirection == false)
        {
            this.transform.position += Vector3.back * copSpeed * Time.deltaTime; 
        }
    }

    void CopMovement()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       if( collision.gameObject.name == "beacon1")
        {
            
            copDirection = false;
        }

       if (collision.gameObject.name == "beacon2")
        {
            copDirection = true;
        }
    }

}
