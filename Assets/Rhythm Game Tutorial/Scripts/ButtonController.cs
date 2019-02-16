using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	private SpriteRenderer sr;
	public Sprite unpressed;
	public Sprite pressed;

	public KeyCode keyToPress;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Vertical") > 0)
		{
			sr.sprite = pressed;
		}

		if (Input.GetKeyUp(keyToPress)) {
			sr.sprite = unpressed;
		}
	}
}
