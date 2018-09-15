using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
	[SerializeField] GameObject defenderPrefab;
	public static GameObject selectedDefender;

	private Button[] buttonArray;
	private Text costText;
	
	// Use this for initialization
	void Start ()
	{
		buttonArray = GameObject.FindObjectsOfType<Button>();

		costText = GetComponentInChildren<Text>();

		if (!costText)
		{
			Debug.LogWarning(name + " has no cost text");
		}
		costText.text = defenderPrefab.GetComponent<Defender>().GetStarCost().ToString();
	}
	
	private void OnMouseDown()
	{
		foreach (Button thisButton in buttonArray)
		{
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}

		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
	}
}