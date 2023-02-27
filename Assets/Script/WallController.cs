using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    BallController ball = null;

    private void OnTriggerEnter2D(Collider2D other) {
        if(ball == null)
            ball = other.GetComponent<BallController>();
        Vector2 velocity = ball.GetVelocity();
        float absX = Mathf.Abs(ball.transform.position.x);
        float absY = Mathf.Abs(ball.transform.position.y);
        if( absX > absY)
            ball.SetVelocity(-velocity.x, velocity.y);
        else if(absY >absX)
            ball.SetVelocity(velocity.x, -velocity.y);
        else
            ball.SetVelocity(-velocity.x, -velocity.y);
    }
}
