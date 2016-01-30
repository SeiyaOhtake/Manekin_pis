using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public PlayerScript Enemy_;
    public int SCORE;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "PlayerBullet")
        {

        }
    }
}
