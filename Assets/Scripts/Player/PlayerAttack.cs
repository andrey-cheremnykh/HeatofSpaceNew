using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 20;
    public int ammoMax = 20;
    public int ammo = 0;
    public TMP_Text ammoText;
    [SerializeField] float fireRange=100000;

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
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,fireRange);
    }
    protected virtual void Fire()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Ray ray = new Ray(transform.position,transform.forward);
                if (ammo <= 0) return;
                ammo--;
                RaycastHit hitInfo;
                Physics.Raycast(ray, out hitInfo, /*fireRange*/Mathf.Infinity);
                if (hitInfo.transform)
                {
                    EnemyHealth en = hitInfo.transform.gameObject.GetComponent<EnemyHealth>();
                    en.GetDamage(damage);
                    print(en.health);
                }
        }

    }
}
