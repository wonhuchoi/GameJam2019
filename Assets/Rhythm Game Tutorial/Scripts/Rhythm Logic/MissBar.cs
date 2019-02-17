﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MissBar : MonoBehaviour {

    public static int missedCount;
    private bool toBeDamaged = false;
	private bool isEnemyHit = false;
	public UnityEvent Miss = new UnityEvent();
	public UnityEvent hitEnemy = new UnityEvent();
    public Transform Explosion;
    // Use this for initialization
    void Start () {
        missedCount = 0;
        Miss.AddListener(MissedNote);
        //Debug.Log(Player.health.ToString());

    }
	
	// Update is called once per frame
	void Update ()

    {
        if (BeatScoller.numNotes <= 1)
        {
			if (toBeDamaged == true)
			{
				DamagePlayer();
			}
			else if (!isEnemyHit)
			{
				HitEnemy();
				isEnemyHit = true;
			}
			missedCount = 0;
			toBeDamaged = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        missedCount++;
        Vector3 pos = other.transform.position;
        Quaternion rot = other.transform.rotation;
        Instantiate(Explosion, pos, rot);
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

	public void HitEnemy()
	{
		isEnemyHit = false;
		hitEnemy.Invoke();
	}

}
