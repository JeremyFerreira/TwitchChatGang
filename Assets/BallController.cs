using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D ballRB;
    [SerializeField] float startSpeed;
    [SerializeField] float currentSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float speedMultiplier;
    [SerializeField] float boundaryRightX;
    [SerializeField] float boundaryLeftX;
    public TrailRenderer trailRenderer;
    public void AddBallSpeed()
    {
        if(currentSpeed< maxSpeed)
        {
            currentSpeed = currentSpeed * speedMultiplier;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();

        LaunchBall();
    }

    // Update is called once per frame
    void Update()
    {
        ballRB.velocity = ballRB.velocity.normalized * currentSpeed;

        ResetBall();

    }

    public void ResetBall()
    {
        if (transform.position.x > boundaryRightX)
        {
            transform.position = Vector3.zero;
            LaunchBall();
            trailRenderer.Clear();
        }
        if (transform.position.x < boundaryLeftX)
        {
            transform.position = Vector3.zero;
            LaunchBall();
            trailRenderer.Clear();
        }
        
    }
    public void LaunchBall()
    {
        //gets a random angle of the ball to start
        float angle = Random.Range(1, 101);
        float dir = Random.Range(-1, 1);
        if (dir == 0)
        {
            dir = 1;
        }

        Vector2 randomDirection = new Vector2(dir, angle / 100);
        randomDirection.Normalize();

        ballRB.velocity = randomDirection * startSpeed;

        currentSpeed = startSpeed;
        
    }
}
