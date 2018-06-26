﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

	private Transform target;
	private int waypointIndex = 0;

	private Enemy enemy;

	// Use this for initialization
	void Start()
	{
		enemy = GetComponent<Enemy>();
		target = Waypoints.points[waypointIndex];
	}

	void Update()
	{
		Vector3 dir = target.position - transform.position;

		transform.Translate(dir.normalized * enemy.speed * Time.deltaTime);

		if (Vector3.Distance(transform.position, target.position) <= 0.2f)
		{
			GetNextWaypoint();
		}

		enemy.speed = enemy.startSpeed;
	}

	private void GetNextWaypoint()
	{
		if (waypointIndex >= Waypoints.points.Length - 1)
		{
			EndPath();
			return;
		}

		waypointIndex++;
		target = Waypoints.points[waypointIndex];
	}


	void EndPath()
	{
		PlayerStats.lives--;
		WaveSpawner.enemiesAlive--;
		Destroy(this.gameObject);
	}
}
