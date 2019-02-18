using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
	public Cameracontroller player;
	float openDoorDistance = 8;
	Animator anim;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Cameracontroller>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player)
		{
			if(Vector3.Distance(player.transform.position, transform.position) < openDoorDistance)
			{
				if (anim)
				{
					print(Vector3.Distance(player.transform.position, transform.position));
					anim.SetBool("character_nearby", true);
				}
			}
			else
			{
				if (anim)
				{
					anim.SetBool("character_nearby", false);
				}
			}
		}
	}
}
