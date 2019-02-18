using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour {
	public List<Transform> camPositionList = new List<Transform>();  //asign all transforms in inspector, including the initial position
	public List<Transform> battlePositionList = new List<Transform>();  //asign all transforms in inspector, including the initial position
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
		if (Input.GetKey(KeyCode.E))
		{
			print(rotating);
			if (!rotating)
				{
					StartCoroutine(Lookaround());
				}
		}
		
		if(clicked)
		{	
			if(clickCounter == 1) { 
				transform.position = Vector3.Lerp(transform.position, camPositionList[1].position, Time.deltaTime);
				print("moved");
				StartRotation(new Vector3(0, 0, 0));
				if (transform.position == camPositionList[clickCounter].position) clicked = false;
			}
			if (clickCounter == 2)
			{
				transform.position = Vector3.Lerp(transform.position, camPositionList[2].position, Time.deltaTime);
				print("moved");
				if (transform.position == camPositionList[clickCounter].position) clicked = false;
			}
			if(clickCounter == 3)
			{
				transform.position = Vector3.Lerp(transform.position, camPositionList[3].position, Time.deltaTime);
				print("moved");
				if (transform.position == camPositionList[clickCounter].position) clicked = false;
			}
			if (clickCounter == 4)
			{
				transform.position = Vector3.Lerp(transform.position, camPositionList[4].position, Time.deltaTime);
				print("moved");
				if (transform.position == camPositionList[clickCounter].position) clicked = false;
			}
			if(clickCounter ==5)
			{
				transform.position = Vector3.Lerp(transform.position, camPositionList[5].position, Time.deltaTime);
				print("moved");
				if (transform.position == battlePositionList[0].position) clicked = false;
			}
			if (clickCounter == 6)
			{
				GameObject.Find("Space_guy (1)").GetComponent<SpriteRenderer>().enabled = false;
				GameObject.Find("Space_guy (1)").GetComponent<SpriteRenderer>().enabled = true;
				GameObject.Find("Space_guy (1)").transform.position = Vector3.Lerp(GameObject.Find("Space_guy (1)").transform.position, new Vector3(-24.51678f, 1, -33.24f), 0.2f);
				transform.position = Vector3.Lerp(transform.position, battlePositionList[0].position, Time.deltaTime);
				print("moved");
				if (transform.position == battlePositionList[0].position) clicked = false;
			}
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
		
		rotating = true;
		float rSpeed = 20;
		float startAngle = transform.eulerAngles.y;
		print(startAngle);
		
		while(transform.eulerAngles.y <= startAngle + 30){
			transform.Rotate(0, Time.deltaTime * rSpeed, 0);
			yield return new WaitForEndOfFrame();
		}
		yield return new WaitUntil(() => transform.eulerAngles.y >= startAngle + 30);
		rSpeed = -20;
		print(transform.eulerAngles.y);
		while (transform.eulerAngles.y >= startAngle -30)
		{
			transform.Rotate(0, Time.deltaTime * rSpeed, 0);
			yield return new WaitForEndOfFrame();
		}
		yield return new WaitUntil(() => transform.eulerAngles.y <= startAngle - 30);
		rSpeed = +20;
		while (transform.eulerAngles.y <= startAngle)
		{
			transform.Rotate(0, Time.deltaTime * rSpeed, 0);
			yield return new WaitForEndOfFrame();
		}
		yield return new WaitUntil(() => transform.eulerAngles.y >= startAngle);
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







