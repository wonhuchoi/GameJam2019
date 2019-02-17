using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MissBar : MonoBehaviour {

    private int missedCount;
    private bool toBeDamaged = false;
    UnityEvent Miss = new UnityEvent();
    // Use this for initialization
    void Start () {
        missedCount = 0;
        Miss.AddListener(MissedNote);
        //Debug.Log(Player.health.ToString());

    }
	
	// Update is called once per frame
	void Update () {
        if (BeatScoller.numNotes <= 1 && toBeDamaged == true)
        {
            DamagePlayer();
            missedCount = 0;
            toBeDamaged = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        missedCount++;
        other.gameObject.SetActive(false);
        Miss.Invoke();
    }

    private void MissedNote()
    {
        if (missedCount >= 2) {
            this.toBeDamaged = true;
        }
        
    }

    private void DamagePlayer()
    {
        Player.health--;
        Debug.Log(Player.health.ToString());
    }

}
