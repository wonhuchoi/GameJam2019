using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {

    private SpriteRenderer sr;
    public Sprite unpressed;
    public Sprite pressed;
    private float DPad;
    private int arrowType; // 0 - up; 1- right; 2 - down; 3 - left
    private GameObject arrowObject;
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
                    if (Input.GetKeyDown(KeyCode.Keypad8) || (Input.GetAxisRaw("Vertical") < 0 && !upArrow))
                    {
                        HitFade.initalize = true;
                        HitFade.resetImage = true;
                        arrowObject.SetActive(false);
                        print("Hit Up!");
                        upArrow = true;
                    }
                    break;
                case 1: // right
                    DPad = Input.GetAxisRaw("Horizontal");
                    if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetAxisRaw("Horizontal") > 0 && !rightArrow)
                    {
                        HitFade.initalize = true;
                        HitFade.resetImage = true;
                        arrowObject.SetActive(false);
                        print("Hit Right!");
                        rightArrow = true;
                    }
                    break;
                case 2: // down
                    DPad = Input.GetAxisRaw("Vertical");
                    if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetAxisRaw("Vertical") > 0 && !downArrow)
                    {
                        HitFade.initalize = true;
                        HitFade.resetImage = true;
                        arrowObject.SetActive(false);
                        print("Hit Down!");
                        downArrow = true;
                    }
                    break;
                case 3: // left
                    DPad = Input.GetAxisRaw("Horizontal");
                    if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetAxisRaw("Horizontal") < 0 && !leftArrow)
                    {
                        HitFade.initalize = true;
                        HitFade.resetImage = true;
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
		if (arrow.gameObject.tag.Contains("Note"))
		{
			arrowType = 4;
		}
	}

	void updateArrowBool()
    {
        if (rightArrow)
            rightArrow = Input.GetAxisRaw("Horizontal") > 0;


        if (leftArrow)
            leftArrow = Input.GetAxisRaw("Horizontal") < 0;

        if (upArrow)
            upArrow = Input.GetAxisRaw("Vertical") < 0;

        if (downArrow)
            downArrow = Input.GetAxisRaw("Vertical") > 0;
    }

}
