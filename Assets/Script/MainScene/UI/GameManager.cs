using UnityEngine;
using System.Collections;

[RequireComponent(typeof(FollowCamera))]
public class GameManager : MonoBehaviour
{	
	public GameObject player;
//	private GameCamera cam;

	
	void Start ()
	{
//		cam = GetComponent<GameCamera>();
		SpawnPlayer();
	}
	
	// Spawn player
	private void SpawnPlayer()
	{
//		cam.SetTarget((Instantiate(player,Vector3.zero,Quaternion.identity) as GameObject).transform);
		GetComponent<FollowCamera> ().target = Instantiate(player, Vector3.zero, Quaternion.identity) as GameObject;
	}
}
