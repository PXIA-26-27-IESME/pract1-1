using UnityEngine;

public class RacketAI : Racket
{
    public Transform ball;
    public GameObject humanRacket;
    private Rigidbody2D _rigidbody2D;
    private float _initialSpeed;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _initialSpeed = moveSpeed;
    }

    protected override void Movement()
    {       
        // Your code here
    }

}
