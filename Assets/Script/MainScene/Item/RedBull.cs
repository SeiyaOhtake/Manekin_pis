using UnityEngine;
using System.Collections;

public class RedBull : MonoBehaviour {
    HealthBarController HBC;//体力表示に必要

    Manekin_Pis MP;
    AudioScript AS;


    // Use this for initialization
    void Start()
    {
        MP = GameObject.FindWithTag("Player").GetComponent<Manekin_Pis>();
        HBC = GameObject.FindWithTag("HealthBar").GetComponent<HealthBarController>();//体力バー関係
        AS = GameObject.FindWithTag("Audio").GetComponent<AudioScript>();
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
            MP.HP++;
            HBC.UpdateHealthBar();
            Destroy(this.gameObject);
            AS.PlayGetItem();
        }
    }
}
