using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBouncePaddle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody))
        {
            Vector2 velocity = rigidbody.velocity;
            float speed = velocity.magnitude;
            velocity = Vector2.Reflect(velocity, Vector2.right);

            //gets a random angle of the ball to start
            float angle = -(transform.position.y - rigidbody.position.y)*3;
            int dir = 0;
            if(velocity.x > 0)
            {
                dir = 1;
            }
            else
            {
                dir = -1;
            }

            Vector2 randomDirection = new Vector2(dir, angle);
            //add the randomdirection to the supposed direction
            rigidbody.velocity = (velocity+randomDirection).normalized;


            BallController ballController =collision.GetComponent<BallController>();
            ballController.AddBallSpeed();
            
        }
    }
}
