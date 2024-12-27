using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] TMP_Text[] moneyTexts;
    // Update is called once per frame
    void Update()
    {
        DisplayMoney(); 
    }
    public void PressButtonGoToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void PressButtonActivatePanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void PressButtonDeactivatePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    void DisplayMoney()
    {
        if (moneyTexts.Length == 0) return;
        for (int i = 0; i < moneyTexts.Length; i++)
        {
            moneyTexts[i].text = "Money: " + PlayerPrefs.GetInt("money");
        }
    }
}
