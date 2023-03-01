using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManger : MonoBehaviour
{
    static LevelManger instance;
    MenuUIManager menuUI;
    [SerializeField] LevelUIManager levelUI;
    [SerializeField] BallSpawner ballSpawner;
    [SerializeField] int totalBricks;
    [SerializeField] int totalBalls;

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

    public bool IsLevelCompleted(){
        return levelUI.gameObject.activeSelf;
    }

    public void LoadNextLevel(){
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = (currentLevel+1) % 5; //update code later
        LoadLevel((Level)nextLevel);
    }

    public void LoadLevel(Level level){
        SceneManager.LoadScene((int)level);
    }

    public int GetNoOfballsToSpawn(){
        return totalBalls;
    }

    public void updateNoOfBricksLeft(){
        totalBricks--;
        if(totalBricks == 0)
            LevelCompleted();
    }

    public void UpdateNoOfBallsLeft(){
        ballSpawner.UpdateNoOfBallsLeft();
    }
}
