using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D ballRB;
    [SerializeField] float startSpeed;
    [SerializeField] float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();

        //gets a random direction of the ball to start
        Vector2 randomDirection = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
        randomDirection.Normalize();

        //check if the ball isnt going straight down or up
        while (randomDirection == Vector2.up || randomDirection == Vector2.down)
        {
            randomDirection = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
            randomDirection.Normalize();
        }
        
        ballRB.velocity = randomDirection * startSpeed;

        currentSpeed = startSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        ballRB.velocity = ballRB.velocity.normalized * currentSpeed;
    }
}
