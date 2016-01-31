using UnityEngine;
using System.Collections;

public class TokoChanBlock : MonoBehaviour
{
	private Animator anim;

	void Start ()
	{
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) {
			anim.SetTrigger ("Goal");
		} else if (col.CompareTag("PlayerBullet")) {
			anim.SetBool ("Guard", true);
		}
	}
}
