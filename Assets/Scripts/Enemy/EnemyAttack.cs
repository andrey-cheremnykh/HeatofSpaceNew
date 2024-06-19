using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] float rageRadius = 10;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerHealth>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckRageRadius();
        transform.LookAt(player);
    }
    void CheckRageRadius()
    {
        Vector3 playerPos = FindObjectOfType<PlayerHealth>().gameObject.transform.position;
        float distanceFromPlayer = Vector3.Distance(transform.position, playerPos);
        if(distanceFromPlayer <= rageRadius)
        {
            StartCoroutine(Fire());
        }
    }
    IEnumerator Fire()
    {
        Vector3 startPos = transform.position;
        Vector3 dir = transform.forward;
        RaycastHit hitInfo;
        Physics.Raycast(startPos, dir, out hitInfo, Mathf.Infinity);
        if (hitInfo.transform)
        {
            PlayerHealth player = hitInfo.transform.gameObject.GetComponent<PlayerHealth>();
            yield return new WaitForSeconds(1);
            player.GetDamage(damage);
        }

    }
}
