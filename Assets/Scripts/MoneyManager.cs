using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public int money = 0;
    [SerializeField] TMP_Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        money = PlayerPrefs.GetInt("money");
    }

    // Update is called once per frame
    void Update()
    {
        DisplayMoney();
    }
    public bool CheckCanPurchaseItem(int price)
    {
        bool canPurchase = false;
        int moneyOld = PlayerPrefs.GetInt("money");
        if (moneyOld >= price)
        {
            canPurchase = true;
            int newMoney = money - price;
            money = newMoney;
            PlayerPrefs.SetInt("money", money);
            return canPurchase;
        }
        else
        {
            canPurchase = false;
            return canPurchase;
        }
    }
    public void SpendMoney(int spending)
    {
        int oldMoney = PlayerPrefs.GetInt("money");
        int newMoney = oldMoney - spending;
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
    void DisplayMoney()
    {
        moneyText.text = "Money " + PlayerPrefs.GetInt("money");
    }
}
