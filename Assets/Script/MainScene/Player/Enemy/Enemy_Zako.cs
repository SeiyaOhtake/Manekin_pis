using UnityEngine;
using System.Collections;

public class Enemy_Zako : MonoBehaviour
{
    public Enemy E;
    //public GameObject EnemyObject;
	[SerializeField]
	int scorePoint = 100;
	[SerializeField]
	int enemyHitPoint = 8;
	[SerializeField]
	GameObject smokeEffect;

	private GameObject instanceSmokeEffect;
    Manekin_Pis MP;

	// Use this for initialization
	void Start () {
        E = new Enemy();
		E.SCORE = scorePoint;//倒した時のスコア
		E.HP = enemyHitPoint;//体力
        MP = GameObject.FindWithTag("Player").GetComponent<Manekin_Pis>();
	}
	
	// Update is called once per frame
	void Update () {
        //体力が0になったら消える
        if (E.HP <= 0)
        {
			Instantiate (smokeEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
            MP.PulsScore(E.SCORE);
        }
        //print(MP.getScore());
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
