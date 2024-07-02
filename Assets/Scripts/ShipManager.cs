using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShipManager : MonoBehaviour
{
    public GameObject[] ships;
    public int selectedShipIndex = 0;
    public int[] shipsUnlockStatus = { };
    public int[] shipsUnlockCost = { 0, 200 };

    MoneyManager moneyManager;
    [SerializeField] GameObject ShipSeectPanel;

    [SerializeField] Camera preSpawnCamera;

    [SerializeField] Slider playerFuelBar, playerHealthBar;
    [SerializeField] TMP_Text ammoText;
    [SerializeField] GameObject DeathUi;
    
    // Start is called before the first frame update
    void Start()
    {
        SetShipUnlock();
        moneyManager = FindObjectOfType<MoneyManager>();
    }
    public void SetShipUnlock()
    {
        Array.Resize(ref shipsUnlockStatus, 2);
        shipsUnlockStatus[0] = PlayerPrefs.GetInt("ship-unlock0");
        shipsUnlockStatus[1] = PlayerPrefs.GetInt("ship-unlock1");
    }
    public void SpawnShip()
    {
        if (shipsUnlockStatus[selectedShipIndex] == 0) 
        {
            print("Cannot spawn ship(locked)");
            return;
        } 

        GameObject spawnedShip = Instantiate(ships[selectedShipIndex], Vector3.zero, Quaternion.identity);
        print(selectedShipIndex);
        spawnedShip.transform.parent = null;
        spawnedShip.GetComponent<SetupUpgrade>().SetAll();
        Destroy(preSpawnCamera.gameObject);

        ShipSeectPanel.SetActive(false);
        spawnedShip.GetComponent<PlayerMove>().fuelbar = playerFuelBar;
        spawnedShip.GetComponent<PlayerAttack>().ammoText = ammoText;
        spawnedShip.GetComponent<PlayerHealth>().healthBar = playerHealthBar;
        spawnedShip.GetComponent<PlayerHealth>().deathUI = DeathUi;
    }
    public void SelectShip(int index)
    {
        if (shipsUnlockStatus[index] == 0)
        {
            print("ship is locked");
            return;
        }
        selectedShipIndex = index;
    }
    public void UnlockShip(int index)
    {
        print("you pressed to unlock " + index);
        if (shipsUnlockStatus[index] == 1)
        {
            print("ship is already unlocked");
            return;
        }

        if (moneyManager.money < shipsUnlockCost[index]) 
        {
            print("you dont have money");
            return;
        } 
        moneyManager.SpendMoney(shipsUnlockCost[index]);

        shipsUnlockStatus[index] = 1;

        string unlockIndex = "ship-unlock" + index;
        PlayerPrefs.SetInt(unlockIndex, 1);
        print("new unlocked status for " + index + "is " + shipsUnlockStatus[selectedShipIndex]);
    }
}
