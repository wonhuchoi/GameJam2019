using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {

    private SpriteRenderer sr;
    public Sprite unpressed;
    public Sprite pressed;
    public float DPad;
    public int arrowType; // 0 - up; 1- right; 2 - down; 3 - left
    public GameObject arrowObject;
    private bool leftArrow;
    private bool rightArrow;
    private bool upArrow;
    private bool downArrow; 

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        arrowType = -1;
        leftArrow = false;
        rightArrow = false;
        upArrow = false;
        downArrow = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (arrowObject != null)
        {
            updateArrowBool();
            switch (arrowType)
            {
                case 0: // up
                    //DPad = Input.GetAxisRaw("Vertical");
                    //print("ALEX TEST UP IS " + upArrow.ToString());
                    if (Input.GetAxisRaw("Vertical") < 0 && !upArrow)
                    {
                        arrowObject.SetActive(false);
                        print("Hit Up!");
                        upArrow = true;
                    }
                    break;
                case 1: // right
                    DPad = Input.GetAxisRaw("Horizontal");
                    if (DPad > 0 && !rightArrow)
                    {
                        arrowObject.SetActive(false);
                        print("Hit Right!");
                        rightArrow = true;
                    }
                    break;
                case 2: // down
                    DPad = Input.GetAxisRaw("Vertical");
                    if (DPad > 0 && !downArrow)
                    {
                        arrowObject.SetActive(false);
                        print("Hit Down!");
                        downArrow = true;
                    }
                    break;
                case 3: // left
                    DPad = Input.GetAxisRaw("Horizontal");
                    if (DPad < 0 && !leftArrow)
                    {
                        arrowObject.SetActive(false);
                        print("Hit Left!");
                        leftArrow = true;
                    }
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D arrow)
    {
        arrowObject = arrow.gameObject;
        switch(arrow.tag)
        {
            case "LeftNote":
                arrowType = 3;
                break;
            case "RightNote":
                arrowType = 1;
                break;
            case "UpNote":
                arrowType = 0;
                break;
            case "DownNote":
                arrowType = 2;
                break;
            default:
                break;
        }
    }

    
    private void OnTriggerExit2D(Collider2D arrow)
    {
        switch (arrow.tag)
        {
            case "LeftNote":
                print("LeftNote");
                arrow.gameObject.SetActive(false);
                break;
            case "RightNote":
                print("RightNote");
                arrow.gameObject.SetActive(false);
                break;
            case "UpNote":
                print("UpNote");
                print("OUTTAHERE");
                arrow.gameObject.SetActive(false);
                break;
            case "DownNote":
                print("DownNote");
                arrow.gameObject.SetActive(false);
                break;
            default:
                print("default");
                break;
        }
        arrowObject = null;
    }
    

    void updateArrowBool()
    {
        if (rightArrow)
        {
            rightArrow = Input.GetAxisRaw("Horizontal") > 0;
        }

        if (leftArrow)
            leftArrow = Input.GetAxisRaw("Horizontal") < 0;

        if (upArrow)
            upArrow = Input.GetAxisRaw("Vertical") < 0;

        if (downArrow)
            downArrow = Input.GetAxisRaw("Vertical") > 0;
    }

}
