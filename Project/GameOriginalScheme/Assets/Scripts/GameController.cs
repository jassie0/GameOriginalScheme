using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance;
    //
    void Awake()
    {
        instance = this;
        _player = GameObject.Find("King");
    }

    private GameObject _player;
    public GameObject Player { get { return _player; } }

}
