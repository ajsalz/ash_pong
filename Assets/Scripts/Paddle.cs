using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D rgbd;
    public float id;
    public float moveSpeed = 2f;
    public float aiDeadZone = 1f;

    private Vector3 startPosition;
    private float moveSpeedMultiplier = 1f;

    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        //Debug.Log("Serial Horizontal: " + SerialController.horizontal);
        float movement = ProcessInput();
        Move(movement);
    }

    private float ProcessInput()
    {
        float movement = 0f;

        //get axis for each player
        switch(id)
        {
            case 1:
                movement = MyMessageListener.horizontal;
                break;
            case 2:
                movement = moveAI();
                break;
        }

        return movement;
    }

    private void Move(float movement)
    {
        Vector2 velo = rgbd.linearVelocity;
        velo.x = moveSpeed * movement * moveSpeedMultiplier;
        rgbd.linearVelocity = velo;
    }

    private float moveAI()
    {
        //Debug.Log($"move ai with id {id}");
        Vector2 ballPos = GameManager.instance.ball.transform.position;
        if (Mathf.Abs(ballPos.x - transform.position.x) > aiDeadZone)
        {
            return ballPos.x > transform.position.x ? 1f : -1f;
        }
        else
        {
            return 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        ball ball = collision.collider.GetComponent<ball>();
        if (ball)
        {

            audioSource.Play();
        }
    }
}

