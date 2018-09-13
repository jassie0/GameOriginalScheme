using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoSingleton<GameController> 
{    
    private static bool _inFightScene = false;
    private static int _nowScene = 0;

    //endless mode
    private const int endlessEnemyMax = 10;
    private const int endlessDingMax = 10;
    private static int endlessEnemyCount = 0;
    private static int endlessDingCount = 0;

    void Awake()
    {
        instance = this;
        InitLevel();

    }

    private void Start()
    {
        SoundManager.Instance().PlayBGM("startSceneBGM");
    }

    public void SetNowScene(int number)
    {
        _nowScene = number;
    }

    public int GetNowScene()
    {
        return _nowScene;
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

    public void PauseGame(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
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
                UIControl.Instance().OpenSingleWindow(UI_TYPE.PauseMain);
            }
        }
    }



}
