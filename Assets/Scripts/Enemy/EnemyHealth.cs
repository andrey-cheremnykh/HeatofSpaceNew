using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    public int defense = 0;
    [SerializeField] Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        defense = Random.Range(1, 10);
        healthBar.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayHealth();
        if (health <= 0) Destroy(gameObject);
    }
    void DisplayHealth()
    {
        healthBar.value = health / 100;

    }

}
