using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    BallController ball = null;

    private void OnTriggerEnter2D(Collider2D other) {
        if(ball == null)
            ball = other.GetComponent<BallController>();
        Vector2 velocity = ball.GetVelocity();
        Vector2 diff = ball.transform.position - transform.position;
        diff = diff.normalized;
        float absX = Mathf.Abs(diff.x);
        float absY = Mathf.Abs(diff.y);
        if( absX > absY)
            ball.SetVelocity(-velocity.x, velocity.y);
        else if(absY >absX)
            ball.SetVelocity(velocity.x, -velocity.y);
        else
            ball.SetVelocity(-velocity.x, -velocity.y);
        Destroy(gameObject);
    }
}
