using UnityEngine;
using System.Collections;

public class Move_Bullet_test : MonoBehaviour {
    public float flap = 5f;//ジャンプする強さ
    //public Rigidbody2D rb;

    public int speed = 10;//弾のスピード

    //private float startTime;

	// Use this for initialization
	void Start () {
        //rb = gameObject.GetComponent<Rigidbody2D>();
        //startTime = Time.time;

        //弾発射
        GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed;
	}
	
	// Update is called once per frame
	void Update () {

        //if (startTime - Time.time % 5 == 0)
        //{
            // (0,1)方向に瞬間的に力を加えて跳ねさせる
            //rb.AddForce(Vector2.left * flap);
        //}

	}
}
