using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int hp = 100;
    public int defense = 5;
    [SerializeField] Slider healthBar;
    [SerializeField] GameObject deathUI;
    // Start is called before the first frame update
    void Start()
    {
        deathUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayHealth();
        if (hp <= 0)
        {
            deathUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void GetDamage(int damage)
    {
        int finalDamage = damage - defense;
        hp -= finalDamage;
    }
    public void DisplayHealth()
    {
        healthBar.value = hp / 100;
    }

}
