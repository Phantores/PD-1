using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 3;
    public float jumpStrength = 4;
    public float climbingSpeed = 1;
    private float horizontalMovement;
    private CharacterController cc;
    private float falling;
    bool isClimbing;
    bool isClimbing;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;
    public GameObject playerModel;
    
    void Awake()
    {
        cc = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isClimbing = false;
    }


    void Update()
    {
        // Input poruszania się
        float horizontalMovement = Input.GetAxis("Horizontal") * speed;

        // Grawitacja
        if (isClimbing == false)
        {
            if (cc.isGrounded == false)
            {
                falling += Physics.gravity.y * Time.deltaTime;
            }

            // Mechanizm skakania
            if (Input.GetKeyDown(upKey) && cc.isGrounded)
            {
                falling = jumpStrength;
            }
        }
        if(Input.GetKey(leftKey)) {
            playerModel.transform.rotation.y = 180;
        } else if(Input.GetKey(rightKey)) {
            playerModel.transform.rotation.y = 0;
        }
        else if (isClimbing == true)
        {
            if(Input.GetKey(upKey))
            {
                falling = climbingSpeed;
            } else if(Input.GetKey(downKey))
            {
                falling = -climbingSpeed;
            } else
            {
                falling = 0;
            }
        }

            // Zsumowanie poprzednich wartości
            Vector3 pM = new Vector3(horizontalMovement, falling, 0);
        
        // Tu się odpala ruszanie gracze
        cc.Move(pM * Time.deltaTime);
    }
    void Climbing()
    {
        isClimbing = true;
    }
    void NotClimbing()
    {
        isClimbing = false;
    }
}
