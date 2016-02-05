using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class FollowCamera : MonoBehaviour
{
	public float interpVelocity;
	public float minDistance;
	public float followDistance;
	public float t;
	public GameObject target;
	public Vector3 offset;
	public float freezeYPos;
	public bool IsFreezeY { get; set; }

	Vector3 targetPos;

	void Awake ()
	{
		IsFreezeY = false;
	}

	void Start () {
		if (target == null)
			target = GameObject.FindWithTag ("Player");
		targetPos = transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (target)
		{
			Vector3 posNoZ = transform.position;
			posNoZ.z = target.transform.position.z;

			Vector3 targetDirection = (target.transform.position - posNoZ);

			interpVelocity = targetDirection.magnitude * 5f;

			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); 
			if (IsFreezeY) targetPos.y = freezeYPos;

			transform.position = Vector3.Lerp( transform.position, targetPos + offset, t);

		}
	}
}

// Original post with image here  >  http://unity3diy.blogspot.com/2015/02/unity-2d-camera-follow-script.html
// for 2D Vertical Scroll Games