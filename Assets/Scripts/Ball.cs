using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Racket leftRacket, rightRacket;
    public Rigidbody2D ballRb;
    public float initialSpeed = 10f;
    private float _moveSpeed;

    private readonly Vector3 _initialPosition = new Vector3(0f, 0f, 0f);
    
    private void Start()
    {
        _moveSpeed = initialSpeed;
        ballRb.linearVelocity = new Vector2(1, 1) * _moveSpeed;
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
            case Tag.LeftWall:
                rightRacket.IncreaseScore();
                StartCoroutine(ResetBall(1));
                break;
            case Tag.RightWall:
                leftRacket.IncreaseScore();
                this.enabled = false;
                StartCoroutine(ResetBall(-1));
                break;
            case Tag.LeftRacket:
                WallBall(collision, 1);
                break;
            case Tag.RightRacket:
                WallBall(collision, -1);
                break;
        }
    }

    private void WallBall(Collision2D collision, int x)
    {
        var a = transform.position.y - collision.gameObject.transform.position.y;
        var b = collision.collider.bounds.size.y;
        var y = a / b;
        ballRb.linearVelocity = new Vector2(x, y)*_moveSpeed;
    }

    private IEnumerator ResetBall(int direction)
    {
        ballRb.linearVelocity = new Vector2(0f, 0f);
        transform.position = _initialPosition;
        yield return new WaitForSeconds(1);
        ballRb.linearVelocity = new Vector2(1 * direction, 1) * initialSpeed;
    }
}
