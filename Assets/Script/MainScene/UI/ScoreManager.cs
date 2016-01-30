using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    Manekin_Pis MP;
    GameObject SCORE_;

    public Text scoreText;

	// Use this for initialization
	void Start () {
        MP = GameObject.FindWithTag("Player").GetComponent<Manekin_Pis>();
        SCORE_ = GameObject.Find("SCORE");
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = MP.getScore().ToString();
	}
}
