using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 20;
    public int ammoMax = 20;
    public int ammo = 0;
    [SerializeField] TMP_Text ammoText;
    // Start is called before the first frame update
    void Start()
    {
        ammo = ammoMax;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayAmmo();
        Fire();
    }
    void DisplayAmmo()
    {
        ammoText.text = ammo + "/" + ammoMax;
    }
    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (ammo <= 0) return;
            ammo--;
            Vector3 origin = Camera.main.transform.position;
            Vector3 dir = Camera.main.transform.forward; 
            RaycastHit hitInfo;
            Physics.Raycast(origin, dir, out hitInfo, Mathf.Infinity);
            if (hitInfo.transform)
            {
                EnemyHealth en = hitInfo.transform.gameObject.GetComponent<EnemyHealth>();
                en.GetDamage();
            }
        }

    }
}
