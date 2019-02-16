using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScoller : MonoBehaviour {

	public float tempo;
	public bool hasStarted;

	// Use this for initialization
	void Start () {
		tempo = tempo / 60f;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted)
		{
			if(Input.anyKeyDown){
				hasStarted = true;
			}
		}
		else
		{
			transform.position -= new Vector3(0f, tempo*Time.deltaTime, 0f);
		}
	}
}
