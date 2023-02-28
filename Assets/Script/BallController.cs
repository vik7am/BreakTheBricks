using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    Vector2 direction;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space))
            MoveInRandomDirection();
    }

    void MoveInRandomDirection(){
        direction = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f));
        //direction = new Vector2(1, 1);
        direction = direction.normalized;
        rb.velocity = speed * direction;
    }
}
