using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownButton : MonoBehaviour
{

	private SpriteRenderer sr;
	public Sprite unpressed;
	public Sprite pressed;

	public KeyCode keyToPress;

	// Use this for initialization
	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		float DPadY = Input.GetAxis("Vertical");
		if (DPadY > 0)
		{
			sr.sprite = pressed;
			//print(DPadY);
		}

		if (DPadY == 0)
		{
			sr.sprite = unpressed;
			//print(DPadY);
		}
	}
}
