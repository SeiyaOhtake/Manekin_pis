/*更新日時2016/01/30　3:14
 * Q.なにこれ
 * A.プレイヤー（敵と自機）のベースのスクリプトです
 * 
 */

using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public int HP;
    //public int SCORE;
    public int Special_Gauge;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int getHP()
    {
        return HP;
    }

    /*public int getScore()
    {
        return SCORE;
    }*/

}
