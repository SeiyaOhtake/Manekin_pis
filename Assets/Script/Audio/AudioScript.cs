using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {
    public AudioSource[] sources;
	// Use this for initialization
	void Start () {
        sources = gameObject.GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //ジャンプ音
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaySE(0);
        }
	}

    public void PlaySE(int i)
    {
        sources[i].Play();
    }
}
