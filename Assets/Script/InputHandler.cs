using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{   
    private float timesSpeed = 1;
    private bool walkON = false;
    public Vector2 vectorFunc { get; private set; }
    

    public void inputUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            walkON = !walkON;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            timesSpeed = 2;
        }

        else if (Input.GetKey(KeyCode.LeftControl) || walkON)
        {
            timesSpeed = 0.5f;
        }
        else
        {
            timesSpeed = 1;
        }

        vectorFunc = (Vector3.right * Input.GetAxisRaw("Horizontal") + Vector3.up * Input.GetAxisRaw("Vertical")).normalized * timesSpeed;

    }
}
