using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

	public TurretBlueprint standardTurret;
	public TurretBlueprint missileTurret;
	public TurretBlueprint laserTurret;

	public void SelectStandardTurret()
	{
		BuildManager.instance.SetTurretToBuild(standardTurret);
	}

	public void SelectMissileTurret()
	{
		BuildManager.instance.SetTurretToBuild(missileTurret);
	}

	public void SelectLaserTurret()
	{
		BuildManager.instance.SetTurretToBuild(laserTurret);
	}

}
