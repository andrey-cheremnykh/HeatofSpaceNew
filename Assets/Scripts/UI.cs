using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    public GameObject diedPanel;
    // Start is called before the first frame update
    void Start()
    {
        diedPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PressButtonGoToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void PressButtonActivatePanel(GameObject panel, bool isActivate)
    {
        panel.SetActive(isActivate);
    }
}
