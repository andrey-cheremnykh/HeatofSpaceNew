using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] TMP_Text[] moneyTexts;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DisplayMoney(); 
    }
    public void PressButtonGoToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void PressButtonSetPanelActive(GameObject panel, bool isActivate)
    {
        panel.SetActive(isActivate);
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
