using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateLevel : MonoBehaviour
{
    public float speed;

    private float inputX;
    private float inputZ;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame)
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            inputX = -1;
            rotate();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            inputZ = 1;
            move();
        }
        else inputZ = 0;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            inputX = 1;
            rotate();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            inputZ = -1;
            move();
        }

        Input.GetAxis("Vertical");

       
       
        if (inputZ != 0)
            move();
      

    }
    void rotate()
    {
        transform.Rotate(new Vector3(0f, inputX * Time.deltaTime * speed, 0f));
    }

    void move()
    {
        transform.position += transform.forward * inputZ * Time.deltaTime * speed;
    }
}