using UnityEngine;
using System.Collections;

public class Move_Test_MP : MonoBehaviour {
    public float flap = 1f;//ジャンプする強さ
    public bool JumpCheck = false;//ジャンプ中か否か
    public Rigidbody2D rb;

    // PlayerBulletプレハブ
    public GameObject bullet;

    // Startメソッドをコルーチンとして呼び出す
    IEnumerator Start()
    {
        while (true)
        {
            // 弾をプレイヤーと同じ位置/角度で作成
            Instantiate(bullet, transform.position, transform.rotation);
            // 0.05秒待つ
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator DestroyBullet()
    {
        while (true)
        {
            // 弾をプレイヤーと同じ位置/角度で作成
            Destroy(bullet);
            // 0.05秒待つ
            yield return new WaitForSeconds(1f);
        }
    }

	// Use this for initialization
	//void Start () {
    //    rb = gameObject.GetComponent<Rigidbody2D>();
    //}
	
	// Update is called once per frame
	void Update () {
	    


        // スペースキーが押されたらジャンプ
        if (Input.GetKeyDown("space"))
        {
            if (!JumpCheck)//ジャンプ中じゃなかったら
            {
                // 落下速度をリセット
                rb.velocity = Vector2.zero;
                // (0,1)方向に瞬間的に力を加えて跳ねさせる
                rb.AddForce(Vector2.up * flap);
                JumpCheck = true;//ジャンプしてるに
            }
        }

        DestroyBullet();
	}
}
