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

    [Space]
    public string damageCurLevelId  = "damage-level";
    public string defenseCurLevelId = "defense-level";
    public string fuelCurLevelId    = "fuel-level";
    public string ammoMaxCurLevelId = "ammo-level";
    void Awake()
    {
        attack = GetComponent<PlayerAttack>();

        SetDamage();
        SetDefense();
        SetFuel();
        SetAmmoMax();
    }
    public void SetDamage()
    {
        int damageCurLevel = PlayerPrefs.GetInt(damageCurLevelId);
        attack.damage = damagePerItemLevel[damageCurLevel];
    }
    public void SetDefense()
    {
        PlayerHealth health = GetComponent<PlayerHealth>();
        int defenseCurLevel = PlayerPrefs.GetInt(defenseCurLevelId);
        health.defense = defensePerItemLevel[defenseCurLevel];
    }
    public void SetFuel()
    {
        PlayerMove move = GetComponent<PlayerMove>();
        int fuelCurLevel = PlayerPrefs.GetInt(fuelCurLevelId);
        move.fuelDecreaseRate = fuelPerItemLevel[fuelCurLevel];

    }
    public void SetAmmoMax()
    {
        int ammoCurLevel = PlayerPrefs.GetInt(ammoMaxCurLevelId);
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
