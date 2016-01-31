using UnityEngine;
using System.Collections;

public class MP_Bullet : MonoBehaviour {
   
    public int speed = 20;//弾のスピード

    public float WaitTime=2.0f;

    public GameObject bullet;
    public GameObject FringPoint;
    MP_FiringPoint MP_FP;

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
        MP_FP = FringPoint.GetComponent<MP_FiringPoint>();
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
                WaitTime = 2.0f;
                //MP_FP.changeBullet(0);
                break;
            case 1://ビール取ったとき
                speed = 40;
                WaitTime = 2.0f;
                //ここで弾の色を変えたい
                //GetComponent<SpriteRenderer>().material.color = Color.yellow;
                //Debug.Log("change color");
                //MP_FP.changeBullet(1);
                break;
            case 2://RedBullをとったとき
                //speed = 30;
                //WaitTime = 0.1f;
                //MP_FP.changeBullet(2);
                break;
        }

    }
}
