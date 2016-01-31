using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class SelectStageController : MonoBehaviour
{
	[SerializeField]
	Text stageText;
	[Space(20)][Header("ステージ設定")][Tooltip("ステージのシーン名を入力")]
	[SerializeField]
	List<string> Stages;
    AudioScript AS;

    private int currentStagePos;
	private int stageLength;

	void Awake ()
	{
		if (stageText == null) {
			stageText = gameObject.GetComponentsInChildren<Text> ()
				.Where(x => x.gameObject.name == "STAGE NAME")
				.Single();
		}

		currentStagePos = 0;
		stageLength = Stages.Count;
		stageText.text = Stages.First ();

        AS = GameObject.FindWithTag("Audio").GetComponent<AudioScript>();
    }

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow)) {
			changeSelectedStage (1);
		} else
		if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow)) {
			changeSelectedStage (-1);
		}

		if (Input.GetKeyDown (KeyCode.Return)) {
			SceneManager.LoadScene (stageText.text);
            AS.PlaySelected();
		}
	}

	private void changeSelectedStage (int d)
	{
		currentStagePos = Mathf.Abs((stageLength + currentStagePos + d) % stageLength);
		stageText.text = Stages [currentStagePos];
        AS.PlaySelect();
	}
}
