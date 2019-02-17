using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour {
	public List<Transform> camPositionList = new List<Transform>();  //asign all transforms in inspector, including the initial position
	public List<Transform> camangleList = new List<Transform>();  //asign all transforms in inspector, including the initial position
	private int clickCounter = 0;
	private bool clicked;
	public float speed = 5.0f;
	private float yRotation = 90f;
	private bool rotating;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(new Vector3(speed * Time.deltaTime*3, 0, 0));
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(new Vector3(-speed * Time.deltaTime * 3, 0, 0));
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(new Vector3(0, 0 , -speed * Time.deltaTime * 3));
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(new Vector3(0,0, speed * Time.deltaTime * 3));
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(new Vector3(0, -speed * Time.deltaTime * 3, 0));
		}
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(new Vector3(0, speed * Time.deltaTime * 3, 0));
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.Rotate(new Vector3(0, -speed * Time.deltaTime*15, 0));
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Rotate(new Vector3(0, speed * Time.deltaTime*15, 0));
		}
		if (Input.GetMouseButtonDown(0)) // this will rgister a click anywhere on the screen, you need to ray cast on your button
		{
			clickCounter++;
			clicked = true;
			clickCounter = Mathf.Clamp(clickCounter, 0, camPositionList.Count - 1); //ensures that number of clicks do not exceed the number of transforms in you list else you might get an Out of Range error
		}
		if (Input.GetMouseButtonDown(0)) // this will rgister a click anywhere on the screen, you need to ray cast on your button
		{
			clickCounter++;
			clicked = true;
			clickCounter = Mathf.Clamp(clickCounter, 0, camPositionList.Count - 1); //ensures that number of clicks do not exceed the number of transforms in you list else you might get an Out of Range error
		}
		if (Input.GetKey(KeyCode.E))
		{
			Startlookingaround();
			print("owiejf");
		}
		if (clicked)
		{
				transform.position = Vector3.Lerp(transform.position, camPositionList[clickCounter].position, Time.deltaTime);
				print("moved");
				if (transform.position == camPositionList[clickCounter].position) clicked = false;
		}
	}
	private IEnumerator Rotate(Vector3 angles, float duration)
	{
		rotating = true;
		Quaternion startRotation = transform.rotation;
		Quaternion endRotation = Quaternion.Euler(angles);
		for (float t = 0; t < duration; t += Time.deltaTime)
		{
			transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
			yield return null;
		}
		transform.rotation = endRotation;
		rotating = false;
	}

	private IEnumerator Lookaround()
	{
		Vector3 leftangle = new Vector3(0, -50, 0);
		Vector3 rightangle = new Vector3(0, 50, 0);
		float duration = 1;
		rotating = true;
		Quaternion originalAngle = transform.rotation;
		Quaternion startRotation = transform.rotation;
		Quaternion endRotation = Quaternion.Euler(leftangle);
		Quaternion endRotation2 = Quaternion.Euler(rightangle);
		for (float t = 0; t < duration; t += Time.deltaTime)
		{
			transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
			yield return null;
		}
		startRotation = endRotation;
		for (float a = 0; a < duration; a += Time.deltaTime)
		{
			transform.rotation = Quaternion.Lerp(startRotation, endRotation2, a / duration);
			yield return null;
		}
		startRotation = endRotation2;
		for (float a = 0; a < duration; a += Time.deltaTime)
		{
			transform.rotation = Quaternion.Lerp(startRotation, originalAngle, a / duration);
			yield return null;
		}
		transform.rotation = originalAngle;
		rotating = false;
	}

	public void StartRotation(Vector3 angle)
	{
		if (!rotating)
			StartCoroutine(Rotate(angle, 1));
	}
	public void Startlookingaround()
	{
		if (!rotating)
			StartCoroutine(Lookaround());
	}
}







