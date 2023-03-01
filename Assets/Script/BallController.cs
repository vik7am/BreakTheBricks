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

    void Start(){
        rb.velocity = transform.up * speed; 
    }

    private void OnTriggerEnter2D(Collider2D other) {
        LevelManger.Instance.UpdateNoOfBalls();
        Destroy(gameObject);
    }
}
