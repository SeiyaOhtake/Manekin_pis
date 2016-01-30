using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditController : MonoBehaviour
{
	[SerializeField]
	Animator creditAnimator;
	[SerializeField]
	float downKeySpeed = 2f;

	void Update ()
	{
		if (Input.GetKey (KeyCode.DownArrow)) {
			creditAnimator.speed = downKeySpeed;
		} else if (Input.GetKeyUp (KeyCode.DownArrow)) {
			creditAnimator.speed = 1f;
		} else if (Input.GetKeyUp (KeyCode.Return)) {
			SceneManager.LoadScene ("Title");
		}
	}
}
