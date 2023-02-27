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

    public Vector2 GetVelocity(){
        return rb.velocity;
    }
    public void SetVelocity(float x, float y){
        velocity = new Vector2(x, y);
    }
}
