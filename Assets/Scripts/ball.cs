using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ball : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public AudioSource audioSource;
    public ParticleSystem collisionParticle;


    public float maxInitialAngle = 0.67f;
    public float moveSpeed = 1f;
    public float maxStartX = 2f;
    public float startY = 0f;
    public float speedMultiplier = 1.1f;


    //public GameManager player;

    private void Start()
    {
        GameManager.instance.onReset += ResetBall;
        GameManager.instance.gameUI.onStartGame += ResetBall;
        audioSource = GetComponent<AudioSource>();
    }

    private void ResetBall()
    {
        ResetBallPosition();
        InitialPush();
    }

    // GET THE BALL MOVING
    private void InitialPush()
    {
        Vector2 dir = Random.value < 0.5f ? Vector2.up : Vector2.down;

        dir.x = Random.Range(-maxInitialAngle, maxInitialAngle);
        rb2d.linearVelocity = dir * moveSpeed;

        EmitParticles(30);
    }

    // RESETS BALL AFTER HITTING DEATH ZONE
    private void ResetBallPosition()
    {
        float posX = Random.Range(-maxStartX, maxStartX);
        Vector2 position = new Vector2(posX, startY);
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();
        if(scoreZone)
        {
            GameManager.instance.OnScoreZoneReached(scoreZone.id);
            ResetBall();
            InitialPush();
            audioSource.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Paddle paddle = collision.collider.GetComponent<Paddle>();
        if(paddle)
        {
            rb2d.linearVelocity *= speedMultiplier;
            EmitParticles(20);
        }
    }

    private void EmitParticles(int amount)
    {
        collisionParticle.Emit(amount);
    }
}


