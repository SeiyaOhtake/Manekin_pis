﻿using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        } else if (col.gameObject.tag == "PlayerBullet")
        {
            gameObject.SetActive(false);
        }
    }
}
