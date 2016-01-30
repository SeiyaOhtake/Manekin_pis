using UnityEngine;
using System.Collections;

public class MP_FiringPoint : MonoBehaviour {

    // PlayerBulletプレハブ
    public GameObject bullet;

    // Startメソッドをコルーチンとして呼び出す
    IEnumerator Start()
    {
        while (true)
        {
            // 弾をプレイヤーと同じ位置/角度で作成
            Instantiate(bullet, transform.position, transform.rotation);
            // 0.05秒間隔で撃つ
            yield return new WaitForSeconds(0.1f);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
