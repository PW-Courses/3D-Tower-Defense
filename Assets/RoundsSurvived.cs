﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour {

	public Text roundsText;

	private void OnEnable()
	{
		StartCoroutine(AnimateText());
	}

	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator AnimateText()
	{
		roundsText.text = "0";
		int round = 0;

		yield return new WaitForSeconds(0.5f);

		while (round < PlayerStats.rounds)
		{
			round++;
			roundsText.text = round.ToString();
			yield return new WaitForSeconds(0.1f);
		}
	}
}
