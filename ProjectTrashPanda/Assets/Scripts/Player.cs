using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Player : MonoBehaviour {
    
   
    public float Speed;
    public float RotateSpeed;
    public float jumpHeight;
    public Text score;

    public GameObject Cop;
    public GameObject tashCan;
    public GameObject HeldStuff;
    public GameObject BackPack;

    private float distanceToCop;
    private float distancetoDrop;



    private bool ControlsEnabled = true;
    private float itemsHeld = 0;
    private bool hasItems = true;
    private int trashOnTheGround = 0;

    // Use this for initialization
    void Start () {
      

    }
	
	// Update is called once per frame
	void Update () {

        

        if (Input.GetKey(KeyCode.A) && ControlsEnabled == true)
        {
            transform.position += Vector3.left * Speed * Time.deltaTime;
            
            //Code below is for rotation mode
           //transform.Rotate(Vector3.down * RotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) && ControlsEnabled == true)
        {
            transform.position += Vector3.right * Speed * Time.deltaTime;

            //Code below is for rotation mode
            //transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime) ;
        }


        if (Input.GetKey(KeyCode.W) && ControlsEnabled == true)
        {
            transform.localPosition += transform.forward * Speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S) && ControlsEnabled == true) 
        {
          transform.localPosition += Vector3.back * Speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space) && ControlsEnabled == true)
        {
            transform.position += Vector3.up * jumpHeight * Time.deltaTime;
        }


        distanceToCop = Vector3.Distance(Cop.transform.position, this.transform.position);
       
        //Player is Spotted
        if (distanceToCop <= 2)
        {
            ControlsEnabled = false;
            
            this.transform.position += new Vector3(1, 1, 0) * Speed * Time.deltaTime;

            if(hasItems == true)
            {
                DropItems();
            }
            
        
        }

        //makes the player wait
        else if(distanceToCop >4)
        {
            ControlsEnabled = true;
            hasItems = true;
        }


        
    }

    void OnCollisionEnter(Collision col)
    {

        if(col.gameObject.name == "Alleyway")
        {
            print("collide alley");
           //Camera.transform.rotation  = Quaternion.LookRotation(CameraRotate, new Vector3(0f,0f,0f));
           //Camera.transform.position = new Vector3(5.31f, 3, 0); 
        }

        if(col.gameObject.tag == "trash")
        {
            Destroy(col.gameObject);

            TrashCan.score += 10;
            BackPack.transform.localScale = new Vector3(BackPack.transform.localScale.x + .10f, BackPack.transform.localScale.y, BackPack.transform.localScale.z + .10f);

            score.text = "Score: " + TrashCan.score;
        }

    }

    void DropItems()
    {
        

        int i = 0;

        //Defines the number of items player is holding
        itemsHeld = (TrashCan.score / 10);
        
        

        //spawns trash
        //if(TrashCan.score > 0)
        //{
            for (i = 0; i <= itemsHeld - 1; i++)
            {
                Vector3 trashLocation = new Vector3(Random.Range((this.transform.position.x - 1), (this.transform.position.x + 1)), this.transform.position.y, Random.Range((this.transform.position.z - 1), (this.transform.position.z + 1)));

                Instantiate(HeldStuff, trashLocation, Quaternion.identity);
                
                //sets score to 0
                TrashCan.score -= 10;
                BackPack.transform.localScale = new Vector3(BackPack.transform.localScale.x - .10f, BackPack.transform.localScale.y, BackPack.transform.localScale.z - .10f);
            //updates score which is stored in TrashCan (which is bad will need to be fixed at a later date)
            score.text = "Score: " + TrashCan.score;

                trashOnTheGround++;
            }


       // }

        hasItems = false;
    }
}
