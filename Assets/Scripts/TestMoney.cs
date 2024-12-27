using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoney : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<MoneyManager>().AddMoney(10000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
