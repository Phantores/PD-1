using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 3;
    public float jumpStrength = 4;
    private float horizontalMovement;
    private CharacterController cc;
    private float falling;
    
    void Awake()
    {
        cc = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        // Input poruszania się
        float horizontalMovement = Input.GetAxis("Horizontal") * speed;
        
        // Grawitacja
        falling += Physics.gravity.y * Time.deltaTime;
        
        // Mechanizm skakania
        if (Input.GetKeyDown(KeyCode.Space) && cc.isGrounded)
        {
            falling = jumpStrength;
        }
        
        // Zsumowanie poprzednich wartości
        Vector3 pM = new Vector3(horizontalMovement, falling, 0);
        
        // Tu się odpala ruszanie gracze
        cc.Move(pM * Time.deltaTime);
    }
}
