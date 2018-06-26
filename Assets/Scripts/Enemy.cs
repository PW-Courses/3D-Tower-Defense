using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float startHealth = 100f;
	private float health;

	public float startSpeed = 10f;
	[HideInInspector]
	public float speed;

	public int worth = 50;

	public GameObject deathEffect;

	public Image healthBarImage;

	private bool isDead = false;

	private void Start()
	{
		speed = startSpeed;
		health = startHealth;
	}

	public void TakeDamage(float amount)
	{
		health -= amount;
		healthBarImage.fillAmount = health / startHealth;

		if (health <= 0 && !isDead)
		{
			Die();
		}
	}

	void Die()
	{
		isDead = true;

		PlayerStats.money += worth;
		WaveSpawner.enemiesAlive--;

		GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity) as GameObject;
		Destroy(effect, 3f);

		Destroy(gameObject);
	}

	public void Slow(float amount)
	{
		speed = startSpeed * (1f - amount);
	}

	// Update is called once per frame
}
