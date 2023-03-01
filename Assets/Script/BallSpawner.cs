using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] int rotationSpeed;
    [SerializeField] BallController ball;
    int noOfBalls;
    bool activated;

    void Start(){
        ResetSpawner();
    }

    void Update(){
        if(activated)
            return;
        CheckForPlayerInput();
    }

    void CheckForPlayerInput(){
        if(Input.GetKey(KeyCode.A) && transform.rotation.z < 0.50f)
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        if(Input.GetKey(KeyCode.D) && transform.rotation.z > -0.50f)
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space)){
            activated = true;
            StartCoroutine(SpawnBall());
        }
    }

    IEnumerator SpawnBall(){
        for(int i=0; i<noOfBalls; i++){
            Instantiate(ball, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void UpdateNoOfBalls(){
        noOfBalls--;
        if(noOfBalls == 0)
            ResetSpawner();
    }

    void ResetSpawner(){
        activated = false;
        noOfBalls = LevelManger.Instance.GetNoOfballs();
    }
}
