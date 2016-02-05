using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MP_FiringPoint : MonoBehaviour {

    MP_Bullet MP_B;

    public bool isRunning;

    public int changeBulletID;

    [SerializeField]
    float bulletRepeatingRate = .1f;

    // PlayerBulletプレハブ
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject bullet2;

    public GameObject currentBullet;
	public bool canShot { get; set; }

	private Slider inputSlider;

    void Awake()
    {
        changeBulletID = 0;
        isRunning = false;
        currentBullet = bullet;
		canShot = true;
    }

    void Start()
    {
        //StartCoroutine("NomalBullet");
        InvokeRepeating("FireBullet", 0f, bulletRepeatingRate);
		GameObject _is = GameObject.FindWithTag ("InputSlider");
		if (_is != null) inputSlider = _is.GetComponent<Slider>();
    }

    void FireBullet()
    {
		if (canShot) {
			GameObject go = Instantiate (currentBullet, transform.position, transform.rotation) as GameObject;
			float fireRange = 0f;
			if (inputSlider != null) fireRange = inputSlider.value;
			go.GetComponent<Rigidbody2D> ().velocity = (transform.right.normalized + (transform.up * fireRange)) * go.GetComponent<MP_Bullet> ().speed;
		}
    }

    // Startメソッドをコルーチンとして呼び出す
    /*IEnumerator Start()
    {
        while (true)
        {
            switch (changeBulletID)
            {
                case 0:
                    // 弾をプレイヤーと同じ位置/角度で作成
                    Instantiate(bullet, transform.position, transform.rotation);
                    // 0.05秒間隔で撃つ
                    yield return new WaitForSeconds(0.1f);
                    break;
                case 1:
                    // 弾をプレイヤーと同じ位置/角度で作成
                    Instantiate(bullet2, transform.position, transform.rotation);
                    // 0.05秒間隔で撃つ
                    yield return new WaitForSeconds(0.1f);
                    break;
            }

        }
    }*/

	
	// Update is called once per frame
	void Update () {
	
	}

    public void changeBullet(int i)
    {
        //StopCoroutine("NomalBullet");
        isRunning = true;
        changeBulletID = i;
        switch (changeBulletID)
        {
            case 0:
                //StartCoroutine("NomalBullet");
                //StopCoroutine(coroutine);
                currentBullet = bullet;
                break;
            case 1:
                //StartCoroutine("BeerBullet");
                currentBullet = bullet2;
                break;
        }
    }

	public void UnableShot ()
	{
		canShot = false;
	}
}
