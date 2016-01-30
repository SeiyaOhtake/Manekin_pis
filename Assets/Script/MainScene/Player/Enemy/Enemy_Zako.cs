using UnityEngine;
using System.Collections;

public class Enemy_Zako : MonoBehaviour {
    public Enemy E;
    public GameObject EnemyObject;

	// Use this for initialization
	void Start () {
        E = new Enemy();
        E.SCORE = 100;//倒した時のスコア
        E.HP = 10;//体力
	}
	
	// Update is called once per frame
	void Update () {
        //体力が0になったら消える
        if (E.HP <= 0)
        {
            Destroy(EnemyObject);
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        //弾を当てるたび一ずつダメージ
        if (coll.gameObject.tag == "PlayerBullet")
        {
            E.HP--;
        }
    }
}
