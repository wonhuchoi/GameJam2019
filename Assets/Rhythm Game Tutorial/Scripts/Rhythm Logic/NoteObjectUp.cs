using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObjectUp : MonoBehaviour {
	public bool canBePressed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float DPadY = Input.GetAxis("Vertical");
		if (DPadY < 0 && this.canBePressed==true)
		{
			this.gameObject.SetActive(false);
		}
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Activator")
		{
			canBePressed = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Activator")
		{
			canBePressed = false;
		}
	}
}
