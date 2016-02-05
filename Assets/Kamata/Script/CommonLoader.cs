using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CommonLoader : MonoBehaviour
{
	void Awake ()
	{
		SceneManager.LoadScene ("GameCommon", LoadSceneMode.Additive);
	}

	void Start ()
	{
		Camera.main.GetComponent<FollowCamera> ().IsFreezeY = true;
	}
}
