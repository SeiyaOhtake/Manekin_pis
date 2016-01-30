using UnityEngine;
using System.Collections;

public class Move_Bullet_test : MonoBehaviour
{
    public float flap = 5f;//ジャンプする強さ

    public int speed = 10;//弾のスピード

    public GameObject bullet;

    IEnumerator DestroyBullet()
    {
        while (true)
        {
            // 弾をプレイヤーと同じ位置/角度で作成
            // 1秒後消す
            yield return new WaitForSeconds(1.0f);
            Destroy(bullet);

        }
    }



    // Use this for initialization
    void Start()
    {
        //弾発射
        GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Stage")
        {
            StartCoroutine("DestroyBullet");
        }
    }
}