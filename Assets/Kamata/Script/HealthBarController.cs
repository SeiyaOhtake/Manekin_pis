using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
	[SerializeField]
	GameObject healthBarParent;
	[SerializeField]
	GameObject healthBarBackgroundParent;
	[SerializeField]
	GameObject healthBar;
	[SerializeField]
	GameObject healthBarBackground;
	[SerializeField]
	bool isDebug = false;

	private int _hp;
	private int _maxHp;

	void Start ()
	{
		_hp = 10; // 仮でHPを設定
		UpdateHealthBar ();
		initHealthBarBackGround ();
	}

	private void initHealthBarBackGround ()
	{
		_maxHp = _hp;

		for (int i = 0; i < _maxHp; i++) {
			GameObject instance = Instantiate (healthBarBackground);
			instance.transform.SetParent (healthBarBackgroundParent.transform);
		}
	}

	public void UpdateHealthBar ()
	{
		//_hp = Player.instance.GetHP(); // TODO: プレイヤーからHPを取得する
		if (healthBarParent.transform.childCount == _hp)
			return;
		
		// remove all healthbar object
		foreach (Transform t in healthBarParent.transform) {
			Destroy (t.gameObject);
		}
		for (int i = 0; i < _hp; i++) {
			GameObject instance = Instantiate (healthBar);
			instance.transform.SetParent (healthBarParent.transform);
		}
	}

//	public void OnHPChanged()
//	{
//		int i = 0;
//		foreach (Transform t in healthBarParent.transform) {
//			++i;
//			if (i > _hp)
//				t.GetComponent<Image> ().sprite = healthBarEmpty;
//		}
//	}

	void OnGUI ()
	{
		if (isDebug) {
			if (GUILayout.Button ("-1")) {
				--_hp;
				UpdateHealthBar ();
			}
			if (GUILayout.Button ("+1")) {
				++_hp;
				UpdateHealthBar ();
			}
		}
	}
}
