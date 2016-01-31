using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        if (Input.GetKey(KeyCode.Space))
        {
            print("ok");
            SceneManager.LoadScene("Title");
        }
	}
}
