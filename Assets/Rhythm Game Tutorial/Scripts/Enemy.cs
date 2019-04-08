using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health;
	public int damageTaken;
    public Transform Explosion;

	// Use this for initialization
	void Start ()
	{
		MissBar missBar = FindObjectOfType<MissBar>();
		missBar.hitEnemy.AddListener(TakeDamage);
		Debug.Log(this.health);
	}

	public void TakeDamage() {
		if (this.gameObject.activeSelf == true)
        {
            Vector3 pos = this.transform.position;
            Quaternion rot = this.transform.rotation;
            //Instantiate(Explosion, pos, rot);
            this.health -= (int)(damageTaken - (MissBar.missedCount * 0.5 * damageTaken));
			if (this.health <= 0)
			{
				this.health = 0;
				this.Die();
			}
		}
		Debug.Log(this.health);

	}

	// Update is called once per frame
	void Update () {
		
	}

	void Die()
    {
        Vector3 pos = this.transform.position;
        Quaternion rot = this.transform.rotation;
        Instantiate(Explosion, pos, rot);
        this.gameObject.SetActive(false);
	}
}
