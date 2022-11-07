using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D ballRB;
    [SerializeField] float startSpeed;
    [SerializeField] float currentSpeed;
    public void setBallSpeed(float speed)
    {
        currentSpeed = speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();

        //gets a random angle of the ball to start
        float angle = Random.Range(1, 101);
        float dir = Random.Range(-1, 1);
        if(dir == 0)
        {
            dir = 1;
        }

        Vector2 randomDirection = new Vector2(dir,angle/100);
        randomDirection.Normalize();
        Debug.Log(randomDirection);

        
        
        ballRB.velocity = randomDirection * startSpeed;

        currentSpeed = startSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        ballRB.velocity = ballRB.velocity.normalized * currentSpeed;
    }
}
