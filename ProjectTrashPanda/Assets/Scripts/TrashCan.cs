using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashCan : MonoBehaviour {

    public float Distance2Player;
    
    public float trashBarSpeed = 5;
    public Text ScoreText;

    public GameObject BackPack;
    public GameObject Player;
    //public GameObject ScoreDisplay;
    public Image TrashBar;
    public GameObject TrashBarParent;
    

    public Camera cam;

    private bool IsEmpty = false;

    static public int score;
    

    private void Awake()
    {
        score = 0;
    }
    // Use this for initialization
    void Start ()
    {
        TrashBar.fillAmount = 0;
        // cam = GetComponent<Camera>();

    }
	
	// Update is called once per frame
	void Update () {

        float Distance = Vector3.Distance(Player.transform.position, transform.position);

        if (Distance <= Distance2Player)
        {
            if (IsEmpty == false)
            {
                TrashBarParent.SetActive(true);

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    UpDateScore();
                }
            }

        }

    }

    void UpDateScore()
    {
        TrashBar.transform.position = cam.WorldToScreenPoint(this.transform.position);

        

        if (TrashBar.fillAmount < 1)
        {
            //TrashBar.transform.localScale += new Vector3(0.1f, 0, 0) * trashBarSpeed * Time.deltaTime;
            TrashBar.fillAmount += .1f * trashBarSpeed * Time.deltaTime;
            
        }
        else
        {
            IsEmpty = true;
            score += 10;
            BackPack.transform.localScale = new Vector3(BackPack.transform.localScale.x + .10f, BackPack.transform.localScale.y, BackPack.transform.localScale.z + .10f);
            TrashBarParent.SetActive(false);

            TrashBar.fillAmount = 0;
        }
        ScoreText.text = "Score " + score;
        
    }
}
