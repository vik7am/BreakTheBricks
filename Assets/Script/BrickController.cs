using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BrickController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] int number;

    void Start() {
        updateText();
    }

    void OnCollisionEnter2D(Collision2D other) {
        number--;
        if(number == 0){
            LevelManger.Instance.updateNoOfBricks();
            Destroy(gameObject);
        }
            
        updateText();
    }

    void updateText(){
        text.text = number.ToString();
    }
}
