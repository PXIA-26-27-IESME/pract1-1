using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Racket LeftRacket, RightRacket;
    public Rigidbody2D ballRb;
    public float initialSpeed = 10f;
    private float moveSpeed;

    private Vector3 _initialPosition = new Vector3(0f, 0f, 0f);
    void Start()
    {
        moveSpeed = initialSpeed;
        ballRb.linearVelocity = new Vector2(1, 1) * moveSpeed;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var tagManager = collision.gameObject.GetComponent<TagManager>();

        GetComponent<AudioSource>().Play();

        if (!tagManager)
        {
            return;
        }

        var myTag = tagManager.wallTag;

        switch (myTag)
        {
            case Tag.leftWall:
                RightRacket.IncreaseScore();
                StartCoroutine(ResetBall(1));
                break;
            case Tag.rightWall:
                LeftRacket.IncreaseScore();
                this.enabled = false;
                StartCoroutine(ResetBall(-1));
                break;
            case Tag.leftRacket:
                WallBall(collision, 1);
                break;
            case Tag.rightRacket:
                WallBall(collision, -1);
                break;
        }
    }

    private void WallBall(Collision2D collision, int x)
    {
        float a = transform.position.y - collision.gameObject.transform.position.y;
        float b = collision.collider.bounds.size.y;
        float y = a / b;
        ballRb.linearVelocity = new Vector2(x, y)*moveSpeed;
    }

    private IEnumerator ResetBall(int direction)
    {
        ballRb.linearVelocity = new Vector2(0f, 0f);
        transform.position = _initialPosition;
        yield return new WaitForSeconds(1);
        ballRb.linearVelocity = new Vector2(1 * direction, 1) * initialSpeed;
    }
}
