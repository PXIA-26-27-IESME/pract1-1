using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class HumanRacket : Racket
{
    private InputSystem_Actions _input;
    
    private void Start()
    {
       _input = new InputSystem_Actions();
       _input.Enable();
    }

    protected override void Movement()
    {
        //float moveAxesValue = Input.GetAxis(axisName) * moveSpeed;
        float moveAxesValue = _input.Player.Move.ReadValue<Vector2>().y * moveSpeed;
            
        rb.linearVelocity = new Vector2(0, moveAxesValue);
    }

}
