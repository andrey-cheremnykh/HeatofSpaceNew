using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuNavigation : MonoBehaviour
{
    [SerializeField] GameObject[] upgradeMenusPerShip;
    [SerializeField] GameObject selectShipMenu;
    [SerializeField] UI uiLogic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenMenu(int menuIndex)
    {
        if (PlayerPrefs.GetInt("ship-unlock" + menuIndex) == 0)
        {
            print("ship is locked");
            return;
        }
        uiLogic.PressButtonSetPanelActive(upgradeMenusPerShip[menuIndex], true);
        uiLogic.PressButtonSetPanelActive(selectShipMenu, false);
    }
}
