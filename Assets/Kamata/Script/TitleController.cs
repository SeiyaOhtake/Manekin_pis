﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
	[SerializeField]
	GameObject selectMenu;
	[SerializeField]
	GameObject selectStage;
    AudioScript AS;

    private List<GameObject> menuList;
	private GameObject _selector;

	void Start ()
	{
		init ();
	}

	void init ()
	{
		menuList = new List<GameObject> ();
		foreach (Text t in selectMenu.GetComponentsInChildren<Text>()) {
			menuList.Add (t.gameObject);
			t.gameObject.GetComponent<TitleSelectMenu> ().SelectorImage.SetActive (false);
		}
		menuList.First().GetComponent<TitleSelectMenu>()
			.SelectorImage.SetActive(true);
        AS = GameObject.FindWithTag("Audio").GetComponent<AudioScript>();
    }

	void Update () {
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			changeSelectMenu (1);
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			changeSelectMenu (menuList.Count - 1);
		} else if (Input.GetKeyDown (KeyCode.Return) && selectMenu.activeSelf == true) {
			select ();
		}
	}

	private void select ()
	{
		string selectedName = GetCurrentSelectGameObject ().transform.parent.name;
		switch (selectedName) {
		case "START":
			pressStart ();
			break;
		case "CREDIT":
			pressCredit ();
			break;
		case "EXIT":
			Application.Quit ();
			break;
		default:
			break;
		}
        AS.PlaySelected();
	}

	private void pressStart ()
	{
		//SceneManager.LoadScene ("Main");
		switchUI ();
	}

	private void switchUI ()
	{
		selectMenu.SetActive (!selectMenu.activeSelf);
		selectStage.SetActive (!selectStage.activeSelf);
	}

	private void pressCredit ()
	{
		SceneManager.LoadScene ("Credit");
	}

	private void changeSelectMenu (int d)
	{
		GameObject currentSelectGameObject = GetCurrentSelectGameObject ();
		int current = menuList.FindIndex (x => x.GetComponent<TitleSelectMenu>().SelectorImage.activeSelf == true);
		GameObject nextSelectGameObject = menuList[Mathf.Abs((current + d) % menuList.Count)].GetComponent<TitleSelectMenu>().SelectorImage;
		nextSelectGameObject.SetActive (true);
		currentSelectGameObject.SetActive (false);
        AS.PlaySelect();
	}

	public GameObject GetCurrentSelectGameObject ()
	{
		return menuList.Select (x => x.GetComponent<TitleSelectMenu> ().SelectorImage)
			.Where(x => x.activeSelf == true)
			.Single();
	}
}
