using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class arrow1 : MonoBehaviour {
	public Cameracontroller player;
	public GameObject[] positions; 
	int positionNo;
	private bool rotating;
	private bool pressed;
	// Use this for initialization
	void Start () {
		int.TryParse(name.Substring(this.name.Length - 1), out positionNo); //1
		rotating = false;
		player = FindObjectOfType<Cameracontroller>();
		positions = GameObject.FindGameObjectsWithTag("Position").OrderBy(go => go.name).ToArray(); ;
		print(positionNo);
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.I))
		{
			pressed = true;
		}
		if(Vector3.Distance(player.transform.position, positions[positionNo-1].transform.position) < 2)
		{
			GetComponent<SpriteRenderer>().enabled = true;
		}

		if(pressed)
		{
			player.transform.position = Vector3.Lerp(player.transform.position, positions[positionNo].transform.position, Time.deltaTime);
			if(positionNo == 1)
			{
				player.StartRotation(new Vector3(0, 0, 0));
			}
			if (Vector3.Distance(player.transform.position, positions[positionNo].transform.position) < 0.1)
			{
				GetComponent<SpriteRenderer>().enabled = false;
				pressed = false;
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

	public void StartRotation(Vector3 angle)
	{
		if (!rotating)
			StartCoroutine(Rotate(angle, 1));
	}
}
