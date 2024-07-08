using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    MoneyManager moneyManager;
    SetupUpgrade setupUpgrade;
    public int[] upgradePrices = {5, 10, 15, 30, 35, 40};
    [SerializeField] GameObject[] playerPrefabs;
    int selectedShipIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
        Initialise();
    }
    public void SelectShip(int index)
    {
        if (PlayerPrefs.GetInt("ship-unlock" + index) == 1)
        {
            selectedShipIndex = index;
            Initialise();
        }
        else print("ship is locked");
    }
    public void Initialise()
    {
        setupUpgrade = playerPrefabs[selectedShipIndex].GetComponent<SetupUpgrade>();
    }
    public void UpgradeDamage()
    {
        string damageId = setupUpgrade.damageCurLevelId;
        int curLevel = PlayerPrefs.GetInt(damageId);

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
