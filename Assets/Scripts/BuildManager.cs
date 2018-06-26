using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	private TurretBlueprint turretToBuild;
	private Node selectedNode;

	public NodeUI nodeUI;

	public GameObject buildEffect;

	private void Awake()
	{
		if (instance)
		{
			Debug.Log("More than one buildmanager in scene!");
			return;
		}

		instance = this;
	}

	public bool CanBuild { get { return turretToBuild != null; } }
	public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

	public void SelectNode(Node node)
	{
		if (selectedNode == node)
		{
			DeselectNode();
			return;
		}

		selectedNode = node;
		turretToBuild = null;

		nodeUI.SetTarget(node);
	}

	public void SetTurretToBuild(TurretBlueprint turret)
	{
		turretToBuild = turret;

		DeselectNode();
	}

	public void DeselectNode()
	{
		selectedNode = null;

		nodeUI.Hide();
	}

	public TurretBlueprint GetTurretToBuild()
	{
		return turretToBuild;
	}
}
