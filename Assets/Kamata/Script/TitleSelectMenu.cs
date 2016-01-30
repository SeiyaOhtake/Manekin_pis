using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleSelectMenu : MonoBehaviour
{
	public GameObject SelectorImage;

	void Awake ()
	{
		SelectorImage = GetComponentInChildren<Image> ().gameObject;
	}
}
