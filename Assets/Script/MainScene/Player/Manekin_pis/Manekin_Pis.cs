using UnityEngine;
using System.Collections;

public class Manekin_Pis : MonoBehaviour {

    // PlayerBulletプレハブ
    //public GameObject bullet;

    public float WalkSpeed = 0.1f;//進んでいくスピード
    public float flap = 9.0f;//ジャンプの強さ
    public bool JumpSwitch = false;//ジャンプしているか否か

    //public PlayerScript PS;//HPとかゲージとか

    public Rigidbody2D rb2d;

	private Animator mannekenPisAnimator;

    HealthBarController HBC;

    public int HP=5;
    public int SCORE=0;
    public int Special_Gauge=0;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
		mannekenPisAnimator = GetComponent<Animator> ();
        HBC = GameObject.FindWithTag("HealthBar").GetComponent<HealthBarController>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(Vector2.right * WalkSpeed);

        // スペースキーが押されたら
        if (Input.GetKeyDown("space"))
        {
            if (!JumpSwitch)//ジャンプ状態じゃなかったら
            {
                // 落下速度をリセット
                rb2d.velocity = Vector2.zero;
                // (0,1)方向に瞬間的に力を加えて跳ねさせる
                rb2d.AddForce(Vector2.up * flap, ForceMode2D.Impulse);
                JumpSwitch = true;
            }
        }

		mannekenPisAnimator.SetFloat("Speed", WalkSpeed);
		mannekenPisAnimator.SetBool ("Jump", JumpSwitch);

        if (HP <= 0)
        {
            //loadlevelを設定すること
            Debug.Log("you died");//デバッグ
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Switch文の方がわかりやすい？

        //地面と当たったら
        if (coll.gameObject.tag == "Stage")
        {
            JumpSwitch = false;//ジャンプしてない状態に
        }
        //敵と当たったら
        if (coll.gameObject.tag == "Enemy")
        {
            HP--;//ダメージが入る。無敵時間モードを実装しなくてもよさげ
            HBC.UpdateHealthBar();
        }
    }

    public int getHP()
    {
        return HP;
    }

    public int getScore()
    {
        return SCORE;
    }

    public void PulsScore(int add)
    {
        SCORE += add;
    }
}
