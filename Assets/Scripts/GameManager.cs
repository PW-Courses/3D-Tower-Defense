using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static bool gameIsOver;

	public GameObject gameOverUI;
	public GameObject completeLevelUI;

	// Use this for initialization
	void Start () {
		gameIsOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameIsOver)
			return;

		if (PlayerStats.lives <= 0)
		{
			EndGame();
		}
	}

	void EndGame()
	{
		gameIsOver = true;
		gameOverUI.SetActive(true);
		Debug.Log("GAME OVER!");
	}

	public void WinLevel()
	{
		gameIsOver = true;
		completeLevelUI.SetActive(true);
	}
}
