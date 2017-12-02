﻿using UnityEngine.UI;
using UnityEngine;

public class AlcoholIndicator : MonoBehaviour {

	private Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Alcohol: " + PlayerStats.alcohol.ToString("0.0") + " ‰";
	}
}
