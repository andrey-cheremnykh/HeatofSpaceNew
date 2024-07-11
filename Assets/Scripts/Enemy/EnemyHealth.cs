using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    public int defense = 0;

    [Space]

    public int income = 10;
    [SerializeField] int minDefense, maxDefense;
    public Slider healthBar;
    MoneyManager moneyManager;

    // Start is called before the first frame update
    void Start()
    {
        defense = Random.Range(minDefense, maxDefense);
        healthBar.value = 0;
        moneyManager = FindObjectOfType<MoneyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayHealth();
        if (health <= 0) 
        {
            moneyManager.AddMoney(income);
            Destroy(gameObject);
        } 

            
    }
    public void DisplayHealth()
    {
        healthBar.value = (float)health / 100;

    }
    public void GetDamage(int initialDamage)
    {
        int finalDamage = initialDamage - defense;
        if (finalDamage <= 0) return;
        health -= finalDamage;
        if (health <= 0) Destroy(gameObject);
        DisplayHealth();
    }

}
