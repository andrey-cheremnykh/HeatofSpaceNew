using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    public float rotateSensitive = 10;
    public float forwardSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Forward();
        Pitch();
        Yaw();
        Roll();
    }
    void Forward()
    {
        // KeyMove(KeyCode.Space, 2, false);
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 forwardVector = new Vector3(0, 0, forwardSpeed);
            rb.AddRelativeForce(forwardVector);
            print(forwardVector.z);
        }
    }
    void Pitch()
    {
        KeyRotate(KeyCode.UpArrow, 0, true);
        KeyRotate(KeyCode.DownArrow, 0, false);
    }
    void Roll()
    {
        KeyRotate(KeyCode.A, 2, false);
        KeyRotate(KeyCode.D, 2, true);
    }
    void Yaw()
    {
        KeyRotate(KeyCode.LeftArrow, 1, true);
        KeyRotate(KeyCode.RightArrow, 1, false);
    }
    void KeyMove(KeyCode key, short whichAxis, bool isNegative)
    {
        float moveAmount = forwardSpeed;
        if (isNegative == true) moveAmount = -moveAmount;
        Vector3 move = Vector3.zero;
        if (whichAxis == 0)
        {
            move = new Vector3(moveAmount, 0, 0);
        }
        else if(whichAxis == 1)
        {
            move = new Vector3(0, moveAmount, 0);
        }
        else if(whichAxis == 1)
        {
            move = new Vector3(0, 0, moveAmount);
        }
        print(move);
        if (Input.GetKey(key))
        {
            rb.AddRelativeForce(move);
        }
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
}
