using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BrickController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] int number;
    [SerializeField] BrickType brickType;

    void Start() {
        if(brickType == BrickType.BREAKABLE_BRICK)
        updateText();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(brickType == BrickType.UNBREAKABLE_BRICK)
            return;
        number--;
        if(number == 0){
            LevelManger.Instance.updateNoOfBricks();
            Destroy(gameObject);
        }
        updateText();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<BallController>()){
            LevelManger.Instance.UpdateNoOfBalls();
            Destroy(other.gameObject);
        }
    }

    void updateText(){
        text.text = number.ToString();
    }
}
