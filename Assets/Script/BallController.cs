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
        if(other.GetComponent<WallController>()){
            WallController wallController = other.GetComponent<WallController>();
            int edgeType = wallController.GetEdgeType(transform.position);
            rb.velocity = direction * speed;
        }
    }

    void updateDirection(int edgeType){
        switch(edgeType){
            case 0: direction = new Vector2(-direction.x, direction.y); break;
            case 1: direction = new Vector2(direction.x, -direction.y); break;
            case 2: direction = new Vector2(-direction.x, -direction.y); break;
        }
    }

    public Vector2 GetVelocity(){
        return rb.velocity;
    }
    public void SetVelocity(float x, float y){
        velocity = new Vector2(x, y);
    }
}
