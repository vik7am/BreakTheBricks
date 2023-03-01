using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] Button start;
    [SerializeField] Button exit;

    void Awake(){
        start.onClick.AddListener(StartGame);
        exit.onClick.AddListener(ExitGame);
    }

    void StartGame(){
        LevelManger.Instance.LoadLevel(Level.LEVEL_1);
    }

    void ExitGame(){
        Application.Quit();
    }
}
