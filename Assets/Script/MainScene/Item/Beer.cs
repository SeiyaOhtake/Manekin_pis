using UnityEngine;
using System.Collections;

public class Beer : MonoBehaviour {

    public int ItemID = 0;
    MP_Bullet MP_B;
    MP_FiringPoint MP_FP;
    [SerializeField]
    GameObject Bullet_Prefab;
    public GameObject FringPoint;

    // Use this for initialization
    void Start()
    {
        MP_B = Bullet_Prefab.GetComponent<MP_Bullet>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //プレイヤーと接触したら
        if (coll.gameObject.tag == "Player")
        {
            MP_FP = GameObject.FindObjectOfType<MP_FiringPoint>();
            MP_B.ChangeBullet(ItemID);
            MP_FP.changeBullet(1);
            //Destroy(GameObject.Find("beer"));
            Destroy(this.gameObject);
        }
    }
}
