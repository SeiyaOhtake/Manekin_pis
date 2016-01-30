using UnityEngine;
using System.Collections;

public class RedBull : MonoBehaviour {

    public int ItemID = 2;
    MP_Bullet MP_B;
    [SerializeField]
    GameObject Bullet_Prefab;

	// Use this for initialization
	void Start () {
        MP_B = Bullet_Prefab.GetComponent<MP_Bullet>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        //プレイヤーと接触したら
        if (coll.gameObject.tag == "Player")
        {
            MP_B.ChangeBullet(ItemID);
            Destroy(GameObject.Find("Redbull"));
        }
    }
}
