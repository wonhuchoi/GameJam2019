using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour {

	private Transform bar;
	// Use this for initialization
	void Start ()
	{
		bar = transform.Find("Bar");

	}

	private void SetSize(float sizeNormalized) {
		bar.localScale = new Vector3(sizeNormalized, 1);
	}

	// Update is called once per frame
}
