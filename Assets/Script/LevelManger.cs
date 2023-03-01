using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManger : MonoBehaviour
{
    static LevelManger instance;
    MenuUIManager menuUI;
    [SerializeField] LevelUIManager levelUI;
    [SerializeField] BallSpawner ballSpawner;
    [SerializeField] int noOfBricks;
    [SerializeField] int noOfBalls;

    public static LevelManger Instance{ get{ return instance; }}

    void Awake()
    {
        if(instance)
            Destroy(this);
        else
            instance = this;
    }

    void LevelCompleted(){
        levelUI.gameObject.SetActive(true);
    }

    public void updateNoOfBricks(){
        noOfBricks--;
        if(noOfBricks == 0)
            LevelCompleted();
    }

    public void LoadNextLevel(){
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = (currentLevel+1) % 5;
        LoadLevel((Level)nextLevel);
    }

    public void LoadLevel(Level level){
        SceneManager.LoadScene((int)level);
    }

    public int GetNoOfballs(){
        return noOfBalls;
    }

    public void UpdateNoOfBalls(){
        ballSpawner.UpdateNoOfBalls();
    }
}
