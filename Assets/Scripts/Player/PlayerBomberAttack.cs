using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class PlayerBomberAttack : PlayerAttack
{
    public int missileCount = 3;
    [SerializeField] float minMaxDot;
    [SerializeField] int hitChancePercent;
    // Start is called before the first frame update
    void Start()
    {
        ammo = ammoMax;
    }   

    // Update is called once per frame
    void Update()
    {
        Fire();
        DisplayAmmo();
    }
    void DisplayAmmo()
    {
        ammoText.text = ammo + "/" + ammoMax;
    }
    protected override void Fire()
    {
        List<EnemyHealth> enemiesToAttack = GetSeenEnemies();
        if (ammo <= 0) return;
        if (Input.GetKeyDown(KeyCode.S))
        {
            for (int i = 0; i < missileCount + 1; i++)
            {
                int enemyIndex = UnityEngine.Random.Range(0, enemiesToAttack.Count);
                int attackChance = UnityEngine.Random.Range(1, 100 / hitChancePercent);
                if (attackChance == 1)
                {
                    enemiesToAttack[enemyIndex].GetDamage(damage);
                    print(enemiesToAttack[enemyIndex].health);
                }
                else
                    return;
            }
            ammo--;
        }
    }
    List<EnemyHealth> GetSeenEnemies()
    {
        float minDot = -minMaxDot;
        List<EnemyHealth> finalEnemies = new List<EnemyHealth>();
        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();
        for (int i = 0; i < enemies.Length; i++) 
        { 
            Vector3 dirToEnemy = Vector3.Normalize(enemies[i].transform.position - transform.position);
            float dot = Vector3.Dot(transform.forward, enemies[i].transform.forward);
            if(dot >= minDot || dot <= minMaxDot)
            {
                finalEnemies.Insert(i, enemies[i]);
            }
        }
        return finalEnemies;
    }
}
