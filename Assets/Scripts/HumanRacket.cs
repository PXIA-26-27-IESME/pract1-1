using UnityEngine;

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
        var moveAxesValue = _input.Player.Move.ReadValue<Vector2>().y * moveSpeed;
        rb.linearVelocity = new Vector2(0, moveAxesValue);
    }

}
