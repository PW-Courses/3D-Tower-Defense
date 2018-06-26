using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public Color hovercolor;
	private Color startColor;

	[HideInInspector]
	public GameObject turret;
	[HideInInspector]
	public TurretBlueprint turretBlueprint;
	[HideInInspector]
	public bool isUpgraded = false;

	private Renderer rend;


	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
	}

	private void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (turret)
		{
			BuildManager.instance.SelectNode(this);
			return;
		}

		if (!BuildManager.instance.CanBuild)
			return;

		BuildTurret(BuildManager.instance.GetTurretToBuild());
	}

	private void BuildTurret(TurretBlueprint blueprint)
	{
		if (!BuildManager.instance.HasMoney)
		{
			Debug.Log("Not enough money!");
			return; // TODO display not enough money
		}

		PlayerStats.money -= blueprint.cost;

		GameObject _turret = Instantiate(blueprint.prefab, transform.position + new Vector3(0f, 0.5f, 0f), Quaternion.identity) as GameObject;
		turret = _turret;

		turretBlueprint = blueprint;

		GameObject effect = Instantiate(BuildManager.instance.buildEffect, transform.position + new Vector3(0f, 0.5f, 0f), Quaternion.identity) as GameObject;
		Destroy(effect, 3f);

		
	}

	public void UpgradeTurret()
	{
		if (PlayerStats.money < turretBlueprint.upgradeCost)
		{
			Debug.Log("Not enough money to upgrade!");
			return; // TODO display not enough money
		}

		PlayerStats.money -= turretBlueprint.upgradeCost;

		// get rid of the old turret
		Destroy(turret);

		//building a new one
		GameObject _turret = Instantiate(turretBlueprint.upgradedPrefab, transform.position + new Vector3(0f, 0.5f, 0f), Quaternion.identity) as GameObject;
		turret = _turret;

		GameObject effect = Instantiate(BuildManager.instance.buildEffect, transform.position + new Vector3(0f, 0.5f, 0f), Quaternion.identity) as GameObject;
		Destroy(effect, 3f);

		isUpgraded = true;
	}

	public void SellTurret()
	{
		PlayerStats.money += turretBlueprint.GetSellAmount();

		//spawn a cool effect

		Destroy(turret);
		turretBlueprint = null;
	}

	private void OnMouseEnter()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;
		if (!BuildManager.instance.CanBuild)
			return;

		if (BuildManager.instance.HasMoney)
		{
			rend.material.color = Color.green;
		} else
		{
			rend.material.color = Color.red;
		}
	}

	private void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}
