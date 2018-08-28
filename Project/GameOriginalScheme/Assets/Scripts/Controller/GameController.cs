﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
    public static GameController instance;
    //
    void Awake()
    {
        instance = this;
        InitLevel();
    }

    private static bool _inFightScene = false;
    private static int _nowScene = 0;

    public void SetNowScene(int number)
    {
        _nowScene = number;
    }

    public void OpenNewScene()
    {
        int openScene = PlayerPrefs.GetInt("Level");
        if(_nowScene >= openScene)
        {
            PlayerPrefs.SetInt("Level", _nowScene + 1);
        }
    }

    public void SetInFightScene(bool isIn)
    {
        _inFightScene = isIn;
    }

    private void InitLevel()
    {
        if(!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 1);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_inFightScene)
            {
                UIControl.instance.OpenWindow(UI_TYPE.PauseMain);
            }
        }
    }

}
