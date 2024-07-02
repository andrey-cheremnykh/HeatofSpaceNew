using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    MoneyManager moneyManager;
    ShipManager shipManager;
    SetupUpgrade setupUpgrade;
    public int[] upgradePrices = {5, 10, 15, 30, 35, 40};
    GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        shipManager = FindObjectOfType<ShipManager>();
        moneyManager = FindObjectOfType<MoneyManager>();
        setupUpgrade = playerPrefab.GetComponent<SetupUpgrade>();

        playerPrefab = shipManager.ships[shipManager.selectedShipIndex];
    }
    public void UpgradeDamage()
    {
        string damageId = setupUpgrade.damageCurLevelId;
        int curLevel = PlayerPrefs.GetInt(damageId);
        print(curLevel);

        bool canPurchase = moneyManager.CheckCanPurchase(upgradePrices[curLevel]);
        if (canPurchase) 
        {
            moneyManager.SpendMoney(upgradePrices[curLevel]);

            int newLevel = curLevel + 1;
            curLevel = newLevel;

            PlayerPrefs.SetInt(damageId, curLevel);
            setupUpgrade.SetDamage();
        }
    }
    public void UpgradeDefense()
    {
        string defenseId = setupUpgrade.defenseCurLevelId;
        int curLevel = PlayerPrefs.GetInt(defenseId);

        bool canPurchase = moneyManager.CheckCanPurchase(upgradePrices[curLevel]);
        if (canPurchase)
        {
            moneyManager.SpendMoney(upgradePrices[curLevel]);
            int newLevel = curLevel + 1;
            curLevel = newLevel;
            PlayerPrefs.SetInt(defenseId, curLevel);
            setupUpgrade.SetDefense();
        }
    }
    public void UpgradeFuel()
    {
        string fuelId = setupUpgrade.fuelCurLevelId;
        int curLevel = PlayerPrefs.GetInt(fuelId);

        bool canPurchase = moneyManager.CheckCanPurchase(upgradePrices[curLevel]);
        if (canPurchase)
        {
            moneyManager.SpendMoney(upgradePrices[curLevel]);
            int newLevel = curLevel + 1;
            curLevel = newLevel;
            PlayerPrefs.SetInt(fuelId, curLevel);
            setupUpgrade.SetFuel();
        }
    }
}
