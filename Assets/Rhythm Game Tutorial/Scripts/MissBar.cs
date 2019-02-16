using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MissBar : MonoBehaviour {

    UnityEvent Miss = new UnityEvent();
    // Use this for initialization
    void Start () {
        Miss.AddListener(MissedNote);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SetActive(false);
        Miss.Invoke();
    }

    private void MissedNote()
    {
        Debug.Log("Missed");
    }

}
