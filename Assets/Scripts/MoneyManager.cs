using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public int money = 0;
    void Start()
    {
        money = PlayerPrefs.GetInt("money");
    }
    public bool CheckCanPurchase(int spending)
    {
        if (money >= spending) return true;
        else return false;
    }
    public void SpendMoney(int price)
    {
        int oldMoney = PlayerPrefs.GetInt("money");
        int newMoney = oldMoney - price;
        money = newMoney;
        PlayerPrefs.SetInt("money", money);
    }
    public void AddMoney(int income)
    {
        int moneyOld = PlayerPrefs.GetInt("money");
        int newMoney = moneyOld + income;
        money = newMoney;
        PlayerPrefs.SetInt("money", money);
    }
}
