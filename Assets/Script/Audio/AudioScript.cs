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
        if(!sources[i].isPlaying)
        {
            sources[i].Play();
        }
        
    }

    public void PlayDamageSound()
    {
        if (!sources[1].isPlaying)
        {
            sources[1].Play();
        }
        
    }

    public void PlayGetItem()
    {
        if (!sources[2].isPlaying)
        {
            sources[2].Play();
        }
    }

    public void PlaySelect()
    {
        if (!sources[3].isPlaying)
        {
            sources[3].Play();
        }
    }
}
