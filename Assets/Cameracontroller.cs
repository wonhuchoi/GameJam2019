using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour {
	public List<Transform> camPositionList = new List<Transform>();  //asign all transforms in inspector, including the initial position
	public List<Transform> camangleList = new List<Transform>();  //asign all transforms in inspector, including the initial position
	private int clickCounter = 0;
	private bool clicked;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) // this will rgister a click anywhere on the screen, you need to ray cast on your button
		{
			clickCounter++;
			clicked = true;
			clickCounter = Mathf.Clamp(clickCounter, 0, camPositionList.Count - 1); //ensures that number of clicks do not exceed the number of transforms in you list else you might get an Out of Range error
		}
		if (clicked)
		{
			transform.position = Vector3.Lerp(transform.position, camPositionList[clickCounter].position, Time.deltaTime);
			if (transform.position == camPositionList[clickCounter].position) clicked = false;
		}
	}
}
