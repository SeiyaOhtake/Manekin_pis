using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Manekin_Pis : MonoBehaviour {

    public float WalkSpeed = 0.1f;//進んでいくスピード
    public float flap = 9.0f;//ジャンプの強さ
    public bool JumpSwitch = false;//ジャンプしているか否か

    public Rigidbody2D rb2d;//Rigidbody ジャンプに必要

	private Animator mannekenPisAnimator;//アニメーター

    HealthBarController HBC;//体力表示に必要

    public int HP=5;//体力
    public static int SCORE=0;//スコア
    public int Special_Gauge=0;//必殺ゲージ（未実装）

    void Start()
    {
        //おまじない一覧
        rb2d = GetComponent<Rigidbody2D>();//重力
		mannekenPisAnimator = GetComponent<Animator> ();//小僧のアニメーター
        HBC = GameObject.FindWithTag("HealthBar").GetComponent<HealthBarController>();//体力バー関係
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(Vector2.right * WalkSpeed);//右に移動し続ける

        // スペースキーが押されたら
        if (Input.GetKeyDown("space"))
        {
            if (!JumpSwitch)//ジャンプ状態じゃなかったら
            {
                // 落下速度をリセット
                rb2d.velocity = Vector2.zero;
                // (0,1)方向に瞬間的に力を加えて跳ねさせる
                rb2d.AddForce(Vector2.up * flap, ForceMode2D.Impulse);
                //飛んでいる状態
                JumpSwitch = true;
            }
        }

		mannekenPisAnimator.SetFloat("Speed", WalkSpeed);
		mannekenPisAnimator.SetBool ("Jump", JumpSwitch);

        if (HP <= 0)//体力が0になったら
        {
            //loadlevelを設定すること
            //Debug.Log("you died");//デバッグ
            //Application.loadedLevel("Result");
            //Application.LoadLevel("Result");
            SceneManager.LoadScene("Result");//Resultへ
            
        }
        //奈落に落ちたらResultへ
        if (this.gameObject.transform.position.y < -30)
        {
            SceneManager.LoadScene("Result");
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
            //Destroy(coll.gameObject);
            HBC.UpdateHealthBar();//体力バー更新
        }
    }
    //HPを返す
    public int getHP()
    {
        return HP;
    }
    //スコアを返す
    public int getScore()
    {
        return SCORE;
    }
    //スコアをプラスする
    public void PulsScore(int add)
    {
        SCORE += add;
    }

    public static int getResultScore()
    {
        return SCORE;
    }

}
