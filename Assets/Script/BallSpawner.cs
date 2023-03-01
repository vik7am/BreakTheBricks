using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] int rotationSpeed;
    [SerializeField] BallController ball;
    int totalBalls;
    int ballsLeft;
    bool readyToShoot;
    float maxLeftSideRange = 0.5f;
    float maxRightSideRange = -0.5f;
    float ballspawnDelay = 0.1f;

    void Start(){
        totalBalls = LevelManger.Instance.GetNoOfballsToSpawn();
        ResetSpawner();
    }

    void Update(){
        if(readyToShoot)
            CheckForPlayerInput();
    }

    void CheckForPlayerInput(){
        if(Input.GetKey(KeyCode.A) && transform.rotation.z < maxLeftSideRange)
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        if(Input.GetKey(KeyCode.D) && transform.rotation.z > maxRightSideRange)
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space)){
            readyToShoot = false;
            StartCoroutine(SpawnBall());
        }
    }

    IEnumerator SpawnBall(){
        for(int i=0; i<totalBalls; i++){
            Instantiate(ball, transform.position, transform.rotation);
            yield return new WaitForSeconds(ballspawnDelay);
        }
    }

    public void UpdateNoOfBallsLeft(){
        ballsLeft--;
        if(ballsLeft == 0)
            ResetSpawner();
    }

    void ResetSpawner(){
        if(LevelManger.Instance.IsLevelCompleted())
            return;
        readyToShoot = true;
        ballsLeft = totalBalls;
    }
}
