using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public static int money;
	public int startMoney = 500;

	public static int lives;
	public int startLives = 20;

	public static int rounds;

	// Use this for initialization
	void Start () {
		money = startMoney;
		lives = startLives;

		rounds = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
