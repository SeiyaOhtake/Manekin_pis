/*更新日時2016/01/30 3:16
 * Q.なにこれ
 * A.弾のベースプログラムです
 * 
 */
using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public int Damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int getDamage()
    {
        return Damage;
    }
}
