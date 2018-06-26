using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

	public GameObject ui;

	public Text upgradeCost;
	public Text sellValue;
	public Button upgradeButton;

	private Node target;

	public void SetTarget(Node node)
	{
		target = node;

		transform.position = target.transform.position + new Vector3(0f, 0.5f, 0f);

		sellValue.text = "$" + target.turretBlueprint.GetSellAmount().ToString();

		if (!target.isUpgraded)
		{
			upgradeButton.interactable = true;
			upgradeCost.text = "$" + target.turretBlueprint.upgradeCost.ToString();
		}
		else
		{
			upgradeButton.interactable = false;
			upgradeCost.text = "MAX";
		}

		ui.SetActive(true);
	}

	public void Hide()
	{
		ui.SetActive(false);
	}

	public void Upgrade()
	{
		target.UpgradeTurret();

		BuildManager.instance.DeselectNode();
	}

	public void Sell()
	{
		target.SellTurret();

		BuildManager.instance.DeselectNode();
	}
}
