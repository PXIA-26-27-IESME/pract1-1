using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Racket : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public string axisName;
    public int Score = 0;
    public Text scoreText;

    void FixedUpdate()
    {
        Movement();

        #region AnotherMovementOption
        //if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        //{
        //    rb.transform.position += Vector3.up;
        //}

        //if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        //{
        //    rb.transform.position += Vector3.down;
        //}
        #endregion

    }

    protected abstract void Movement();

    public void IncreaseScore(){
        Score++;
        scoreText.text = Score.ToString();
    }

    

}
