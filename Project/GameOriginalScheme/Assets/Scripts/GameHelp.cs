using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHelp : MonoBehaviour {

    public static GameHelp instance;

    void Awake()
    {
        instance = this;
    }

    public static Quaternion GetQuaternion(Direction dir)
    {
        if (dir == Direction.Up)
        {
            return Quaternion.Euler(Vector3.up);
        }
        else if (dir == Direction.Right)
        {
            return Quaternion.Euler(Vector3.right);
        }
        else if (dir == Direction.Down)
        {
            return Quaternion.Euler(Vector3.down);
        }
        else if (dir == Direction.Left)
        {
            return Quaternion.Euler(Vector3.left);
        }
        else
        {
            return Quaternion.Euler(Vector3.zero);
        }
    }
}
