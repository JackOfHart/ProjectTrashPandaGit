using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    public float Distance2Trash;
    public float score;
    public float trashBarSpeed = 5;
    public Text ScoreText;
    

    public GameObject TrashCan;
    public GameObject Player;
    public Image TrashBar;
    public GameObject TrashBarParent;

    private bool IsEmpty = false;

    // Use this for initialization
    void Start() {
        
        TrashBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update() {

        
        float Distance = Vector3.Distance(Player.transform.position, TrashCan.transform.position);

        if (Distance <= Distance2Trash)
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
        if (TrashBar.fillAmount < 1)
        {
            //TrashBar.transform.localScale += new Vector3(0.1f, 0, 0) * trashBarSpeed * Time.deltaTime;
            TrashBar.fillAmount += .1f * trashBarSpeed * Time.deltaTime;
            print(TrashBar.fillAmount);
        }
        else
        {
            IsEmpty = true;
            score += 10;
            TrashBarParent.SetActive(false);


        }
        ScoreText.text = "Score" + score;
    }
}
