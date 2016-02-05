using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CircleCollider2D))]
public class GoalTargetObject : MonoBehaviour
{
	[SerializeField]
	float circleRadius = .32f;
	[SerializeField]
	float waitTime = 2f;

	private CircleCollider2D circleCollider2D;
//	private Animator anim;

	void Awake ()
	{
		circleCollider2D = GetComponent<CircleCollider2D> ();
		circleCollider2D.isTrigger = true;
		circleCollider2D.radius = circleRadius;
//		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Player") {
			// Stop walking
			col.GetComponent <Manekin_Pis>().WalkSpeed = 0f;
//			anim.SetTrigger ("Goal");

			// Stop Pis
			col.BroadcastMessage("UnableShot");

			// reset Camera offset
			Camera.main.GetComponent<FollowCamera>().offset = Vector3.zero;

			// Go to result scene after waitTime sec.
			Invoke ("GetGoal", waitTime);
		}
	}

	void GetGoal ()
	{
        SceneManager.LoadScene("Result");
	}
}
