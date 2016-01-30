using UnityEngine;
using System.Collections;

public class MP_Bullet : MonoBehaviour {
   
    public int speed = 20;//弾のスピード

    public float WaitTime=1.0f;

    public GameObject bullet;

    IEnumerator DestroyBullet()
    {
        while (true)
        {
            // 弾をプレイヤーと同じ位置/角度で作成
            // 1秒後消す
            yield return new WaitForSeconds(WaitTime);
            Destroy(bullet);

        }
    }
	// Use this for initialization
	void Start () {
        //弾発射
        GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        StartCoroutine("DestroyBullet");
    }

    public void ChangeBullet(int i)
    {
        switch (i)
        {
            case 0://通常
                speed = 20;
                WaitTime = 1.0f;
                break;
            case 1://ビール取ったとき
                speed = 30;
                WaitTime = 0.5f;
                //bullet.renderer.
                break;
            case 2://RedBullをとったとき
                speed = 30;
                WaitTime = 0.1f;
                break;
        }

    }
}
