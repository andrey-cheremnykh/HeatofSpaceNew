using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    float fuel = 100;
    public float fuelDecreaseRate = 0.1f;
    float howLongWaitOfFuelDecrease = 0.5f;
    PlayerHealth health;
    int hp = 0;

    [Space]

    public float rotateSensitive = 10;
    public float forwardSpeed;
    public bool isInvertedPitch = true;
    public Slider fuelbar;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        hp = health.hp;
        fuelbar.value = fuel / 100;
        Forward();
        Pitch();
        Yaw();
        Roll();
        if (Input.GetKeyDown(KeyCode.H)) 
        { 
            SceneManager.LoadScene(0/*menu*/); 
        }
    }
    void Forward()
    {
        if (hp <= 0) return;
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(DepleteFuel());
            if (fuel <= 0) return;
            Vector3 forwardVector = new Vector3(0, 0, forwardSpeed);
            rb.AddRelativeForce(forwardVector);
        }
    }
    void Pitch()
    {
        if (hp <= 0) return;
        if (isInvertedPitch == false)
        {
            KeyRotate(KeyCode.UpArrow, 0, true);
            KeyRotate(KeyCode.DownArrow, 0, false);
        }
        else
        {
            KeyRotate(KeyCode.UpArrow, 0, false);
            KeyRotate(KeyCode.DownArrow, 0, true);
        }
    }
    void Roll()
    {
        if (hp <= 0) return; 
        KeyRotate(KeyCode.A, 2, false);
        KeyRotate(KeyCode.D, 2, true);
    }
    void Yaw()
    {
        if (hp <= 0) return;
        KeyRotate(KeyCode.LeftArrow, 1, true);
        KeyRotate(KeyCode.RightArrow, 1, false);
    }
    void KeyRotate(KeyCode key, short whichAxis,bool isNegative)
    {
        float rotateAmount = rotateSensitive;
        if (isNegative == true) rotateAmount = -rotateAmount;
        Vector3 rotateFinal = Vector3.zero;
        if (whichAxis == 0) 
        {
            rotateFinal = new Vector3(rotateAmount, 0, 0);
        }
        else if (whichAxis == 1)
        {
            rotateFinal = new Vector3(0, rotateAmount, 0);
        }
        else if (whichAxis == 2)
        {
            rotateFinal = new Vector3(0, 0, rotateAmount);
        } 
            
        if (Input.GetKey(key))
        {
            transform.Rotate(rotateFinal, Space.Self);
        }
    }
    IEnumerator DepleteFuel()
    {
        yield return new WaitForSeconds(howLongWaitOfFuelDecrease);
        fuel -= fuelDecreaseRate;
    }
    private void OnTriggerEnter(Collider other)
    {
        CheckTagForCollider(other);
        
    }
    void CheckTagForCollider(Collider whatCollider)
    {
        if(whatCollider.CompareTag("Refuel Here"))
        {
            fuel = 100;
            fuelbar.value = 1;
        }
        else if(whatCollider.gameObject.CompareTag("Reload Here"))
        {
            PlayerAttack myAttack = GetComponent<PlayerAttack>();
            myAttack.ammo = myAttack.ammoMax;
        }
       
    }
    bool CheckIsAlive()
    {
        PlayerHealth playerHealth = GetComponent<PlayerHealth>();
        bool isAlive = true;
        if (playerHealth.hp <= 0)
        {
            isAlive = false;
        }
        else
        {
            isAlive = true;
        }
        return isAlive;
    }
}
