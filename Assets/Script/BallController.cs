using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifeTime;
    Rigidbody2D rb;
    Vector2 direction;
    

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Start(){
        rb.velocity = transform.up * speed; 
    }

    void Update() {
        lifeTime -= Time.deltaTime;
        if(lifeTime<=0)
            DestroyBall();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DestroyBall();
    }

    void DestroyBall(){
        LevelManger.Instance.UpdateNoOfBallsLeft();
        Destroy(gameObject);
    }
}
