using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    Vector2 direction;
    Vector2 velocity;
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        velocity = Vector2.zero;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            direction = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f));
            velocity = speed * direction.normalized;
        }
    }

    private void FixedUpdate() {
        rb.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        float absX = Mathf.Abs(transform.position.x);
        float absY = Mathf.Abs(transform.position.y);
        if( absX > absY)
            velocity = new Vector2(-velocity.x, velocity.y);
        else if(absY >absX)
            velocity = new Vector2(velocity.x, -velocity.y);
        else
            velocity = -velocity;
    }
}
