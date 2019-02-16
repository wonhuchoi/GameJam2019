using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButton : MonoBehaviour
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
		float DPadX = Input.GetAxis("Horizontal");
		if (DPadX > 0)
		{
			sr.sprite = pressed;
			print(DPadX);
		}

		if (DPadX == 0)
		{
			sr.sprite = unpressed;
			print(DPadX);
		}
	}
}
