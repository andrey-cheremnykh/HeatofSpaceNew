using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]int speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().GetDamage();
            Destroy(gameObject);
        }
    }
    public void Launch()
    {
        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();
        int enemyIndex = Random.Range(0, enemies.Length);
        transform.LookAt(enemies[enemyIndex].transform);
        rb.velocity = Vector3.forward * speed;
    }
}
