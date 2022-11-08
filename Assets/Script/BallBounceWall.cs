using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounceWall : MonoBehaviour
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
        if (collision.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody))
        {
            AudioManager.instance.playSoundEffect(0, 1);
            AudioManager.instance.ChangePitch(AudioManager.instance.GetPitch()*1.05f);
            Vector2 velocity = rigidbody.velocity;
            velocity = Vector2.Reflect(velocity, Vector2.up);
            rigidbody.velocity = velocity;
        }
    }
}
