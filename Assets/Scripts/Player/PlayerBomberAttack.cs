using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class PlayerBomberAttack : PlayerAttack
{
    public int missileCount = 3;
    bool canFire = true;
    [SerializeField] float minMaxDot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        DisplayCanFire(ammoText);
    }
    protected override void Fire()
    {
        List<EnemyHealth> enemiesToAttack = GetSeenEnemies();
        if (canFire == false) return;
        if (Input.GetKeyDown(KeyCode.S))
        {
            for (int i = 0; i < missileCount + 1; i++)
            {
                int enemyIndex = UnityEngine.Random.Range(0 , enemiesToAttack.Count);
                enemiesToAttack[enemyIndex].GetDamage(damage);
                print(enemiesToAttack[enemyIndex].health);
            }
            canFire = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reload Here")
        {
            canFire = true;
        }
    }
    void DisplayCanFire(TMP_Text text)
    {
        if (canFire == true) text.text = "Can Fire";
        else text.text = "Can't Fire";
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
