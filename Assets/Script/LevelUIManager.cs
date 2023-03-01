using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIManager : MonoBehaviour
{
    [SerializeField] Button nextLevel;
    [SerializeField] Button exit;

    void Awake(){
        nextLevel.onClick.AddListener(StartNextLevel);
        exit.onClick.AddListener(ExitGame);
    }

    void StartNextLevel(){
        LevelManger.Instance.LoadNextLevel();
    }

    void ExitGame(){
        Application.Quit();
    }
}
