using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour {

    public int resultScore;

    public Text scoreText;

	// Use this for initialization
	void Start () {
        resultScore = Manekin_Pis.getResultScore();//ここでMainからスコアを持ってくる
        scoreText.text = "SCORE:" + resultScore;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
