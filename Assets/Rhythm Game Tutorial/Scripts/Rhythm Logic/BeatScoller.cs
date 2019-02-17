using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScoller : MonoBehaviour {

	public float tempo;
	public bool hasStarted;
    public static int numNotes;

	// Use this for initialization
	void Start () {
		tempo = tempo / 60f;
        numNotes = 0;

        numNotes = GetComponentsInChildren<Transform>().GetLength(0);

        //Debug.Log(numNotes.ToString());
    }
	
	// Update is called once per frame
	void Update () {
        numNotes = GetComponentsInChildren<Transform>().GetLength(0);

        //Debug.Log(numNotes.ToString());
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
