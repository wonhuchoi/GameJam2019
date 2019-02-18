using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MissBar : MonoBehaviour
{

    public static int missedCount;
    private bool toBeDamaged = false;
    private bool isEnemyHit = false;
    public UnityEvent Miss = new UnityEvent();
    public UnityEvent hitEnemy = new UnityEvent();
    public Transform Explosion;
    // Use this for initialization
    void Start()
    {
        missedCount = 0;
        Miss.AddListener(MissedNote);
        //Debug.Log(Player.health.ToString());

    }

    // Update is called once per frame
    void Update()

    {
        if (BeatScoller.numNotes <= 0)
        {
            if (toBeDamaged == true)
            {
                print("DAMAGE TIME");
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
        MissFade.initalize = true;
        MissFade.resetImage = true;
        missedCount++;
        Vector3 pos = other.transform.position;
        Quaternion rot = other.transform.rotation;
        other.gameObject.SetActive(false);
        Miss.Invoke();
    }

    private void MissedNote()
    {
        print("MISSED NOTE CALLED");
        if (missedCount >= 2)
        {
            toBeDamaged = true;
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