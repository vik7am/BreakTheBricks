using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    BallController ball = null;

    public int GetEdgeType(Vector2 position){
        float absX = Mathf.Abs(position.x);
        float absY = Mathf.Abs(position.y);
        if(absX > absY)
            return 0;
        else if(absY >absX)
            return 1;
        else
            return 2;
    }
}
