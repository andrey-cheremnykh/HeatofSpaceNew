using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] float rageRadius = 10;
    [SerializeField] public float fireInterval = 1;
    [SerializeField] float testtest = 4;
    float fireTimer;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerHealth>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        print("cololress" + testtest);
        print("fire interval is" + fireInterval);
        CheckRageRadius();
        transform.LookAt(player);
    }
    void CheckRageRadius()
    {
        Vector3 playerPos = FindObjectOfType<PlayerHealth>().gameObject.transform.position;
        float distanceFromPlayer = Vector3.Distance(transform.position, playerPos);
        if(distanceFromPlayer <= rageRadius)
        {
            Fire();
        }
    }
    void Fire()
    {
        fireTimer += Time.deltaTime;
        print("timer is "+fireTimer);
        print(fireInterval);
        if (fireTimer >= fireInterval)
        {
            print("It's time!!!");
            fireTimer = 0;
            print("timer now "+fireTimer);
            // print("fire interval is "+fireInterval);
            Vector3 startPos = transform.position;
            Vector3 dir = transform.forward;
            RaycastHit hitInfo;
            Physics.Raycast(startPos, dir, out hitInfo, Mathf.Infinity);
            if (hitInfo.transform)
            {
                print("Hit!");
                PlayerHealth player = hitInfo.transform.gameObject.GetComponent<PlayerHealth>();
                player.GetDamage(damage);
            }
        }
    }
}
