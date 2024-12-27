using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupUpgrade : MonoBehaviour
{
    PlayerAttack attack;
    public int[] damagePerItemLevel  = {10, 12, 14, 16, 18, 20};
    public int[] defensePerItemLevel = {5, 7, 9, 11, 13, 15};
    public float[] fuelPerItemLevel  = {0.1f, 0.07f, 0.05f, 0.04f};
    public int[] ammoMaxPerItemLevel = {20, 30, 50, 60, 70, 80};
    public int damageLevel;
    public int defenseLevel;
    ShipManager shipManager;
    int thisShipIndex;


    [Space]
    public string damageCurLevelId  = "damage-level";
    public string defenseCurLevelId = "defense-level";
    public string fuelCurLevelId    = "fuel-level";
    public string ammoMaxCurLevelId = "ammo-level";
    void Awake()
    {
        attack = GetComponent<PlayerAttack>();
        shipManager = FindObjectOfType<ShipManager>();
        thisShipIndex = System.Array.IndexOf(shipManager.ships, gameObject);
        print("attack of setupupgarade is "+attack);

        SetDamage();
        SetDefense();
        SetFuel();
        SetAmmoMax();
    }
    public void SetDamage()
    {
        int damageCurLevel = PlayerPrefs.GetInt(damageCurLevelId + thisShipIndex);
        attack.damage = damagePerItemLevel[damageCurLevel];
        print("attack was set to "+attack);
    }
    public void SetDefense()
    {
        PlayerHealth health = GetComponent<PlayerHealth>();
        int defenseCurLevel = PlayerPrefs.GetInt(defenseCurLevelId + thisShipIndex);
        health.defense = defensePerItemLevel[defenseCurLevel];
    }
    public void SetFuel()
    {
        PlayerMove move = GetComponent<PlayerMove>();
        int fuelCurLevel = PlayerPrefs.GetInt(fuelCurLevelId+ thisShipIndex);
        move.fuelDecreaseRate = fuelPerItemLevel[fuelCurLevel];

    }
    public void SetAmmoMax()
    {
        int ammoCurLevel = PlayerPrefs.GetInt(ammoMaxCurLevelId + thisShipIndex);
        attack.ammoMax = ammoMaxPerItemLevel[ammoCurLevel];
    }
    public void SetAll()
    {
        SetDamage();
        SetDefense();
        SetFuel();
        SetAmmoMax();
    }
}
