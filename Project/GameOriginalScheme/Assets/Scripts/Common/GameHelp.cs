using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHelp : MonoBehaviour 
{
    public static GameHelp instance;

    void Awake()
    {
        instance = this;
    }

}
