using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public abstract class Racket : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public string axisName;
    [FormerlySerializedAs("Score")] public int score = 0;
    public Text scoreText;

    private void FixedUpdate()
    {
        Movement();
    }

    protected abstract void Movement();

    public void IncreaseScore(){
        score++;
        scoreText.text = score.ToString();
    }
}
