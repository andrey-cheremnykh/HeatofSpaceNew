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
    GameObject selectedShip;

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
        selectedShip = playerPrefabs[selectedShipIndex];
        print("seected ship is"+selectedShip);
        setupUpgrade = selectedShip.GetComponent<SetupUpgrade>();

    }
    public void UpgradeTrait(int traitId)//0 for damage, 1 for dsefense, 2 for fuel, 3 for ammo
    {
        string[] IDs = { setupUpgrade.damageCurLevelId, setupUpgrade.defenseCurLevelId, setupUpgrade.fuelCurLevelId, setupUpgrade.ammoMaxCurLevelId };
        string IdToUse = IDs[traitId] + selectedShipIndex;
        int curLevel = PlayerPrefs.GetInt(IdToUse);

        bool canPurchase = moneyManager.CheckCanPurchase(upgradePrices[curLevel]);
        if (canPurchase)
        {
            moneyManager.SpendMoney(upgradePrices[curLevel]);

            print("current level is " + curLevel);
            int newLevel = curLevel + 1;
            curLevel = newLevel;
            print("new level is " + curLevel);
            PlayerPrefs.SetInt(IdToUse, curLevel);
        }
    }
    public void UpgradeDamage()
    {
        string damageId = setupUpgrade.damageCurLevelId + selectedShipIndex;
        int curLevel = PlayerPrefs.GetInt(damageId);
        print("current level is " + curLevel);

        bool canPurchase = moneyManager.CheckCanPurchase(upgradePrices[curLevel]);
        print("canPurchase = " + canPurchase);
        if (canPurchase) 
        {
            moneyManager.SpendMoney(upgradePrices[curLevel]);

            int newLevel = curLevel + 1;
            curLevel = newLevel;
            print("new level is " + curLevel);
            PlayerPrefs.SetInt(damageId, curLevel);
        }
    }
    public void UpgradeDefense()
    {
        string defenseId = setupUpgrade.defenseCurLevelId + selectedShipIndex;
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
        string fuelId = setupUpgrade.fuelCurLevelId + selectedShipIndex;
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
