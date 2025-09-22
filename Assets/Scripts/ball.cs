using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ball : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rb2d;
    public float maxInitialAngle = 0.67f;
    public float moveSpeed = 1f;
    public float maxStartX = 2f;
    public float startY = 0f;

    public AudioSource audioSource;

    private void Start()
    {
        InitialPush();
        audioSource = GetComponent<AudioSource>();
    }

    // GET THE BALL MOVING
    private void InitialPush()
    {
        Vector2 dir = Random.value < 0.5f ? Vector2.up : Vector2.down;

        dir.x = Random.Range(-maxInitialAngle, maxInitialAngle);
        rb2d.linearVelocity = dir * moveSpeed;
    }

    // RESETS BALL AFTER HITTING DEATH ZONE
    private void ResetBall()
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
            gameManager.OnScoreZoneReached(scoreZone.id);
            //Debug.Log("hehe");
            ResetBall();
            InitialPush();
            audioSource.Play();
        }
    }
}


