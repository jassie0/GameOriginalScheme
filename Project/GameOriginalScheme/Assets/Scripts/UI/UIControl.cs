﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UI_TYPE
{
    None,
    StartPlay,
    PauseMain,
    PauseOption,
    SelectMode,
    SelectLevel,
    Loading,
    GameOver,
    Endless,
    TrainingSession,
    MovingTips
}

public class UIControl : MonoBehaviour
{
    [HideInInspector]
    public static UIControl instance;

    private void Awake()
    {
        instance = this;
        InitDict();
    }

    public List<UIWindow> m_windowList;
    private static Dictionary<UI_TYPE, UIWindow> m_windowDict = new Dictionary<UI_TYPE, UIWindow>();

    public UIWindow GetWindow(UI_TYPE type)
    {
        if (m_windowDict.ContainsKey(type))
        {
            return m_windowDict[type];
        }

        return null;
    }


    public void CloseAllWindow()
    {
        foreach (UIWindow w in m_windowDict.Values)
        {
            w.Close();
        }
    }

    public void OpenSingleWindow(UI_TYPE type)
    {
        foreach(UIWindow w in m_windowDict.Values)
        {
            if(w.TYPE != type)
            {
                if(w.TYPE == UI_TYPE.Loading)
                {
                    return;
                }
                w.Close();
            }
            else
            {
                w.Open();
            }
        }
    }

    public void CloseWindow(UI_TYPE type)
    {
        if (m_windowDict.ContainsKey(type))
        {
            m_windowDict[type].Close();
        }
    }

    public void OpenWindow(UI_TYPE type)
    {
        if (m_windowDict.ContainsKey(type))
        {
            m_windowDict[type].Open();
        }
    }

    private void InitDict()
    {
        if(m_windowList.Count > 0)
        {
            for (int i = 0; i < m_windowList.Count; i++)
            {
                if(!m_windowDict.ContainsKey(m_windowList[i].TYPE))
                {
                    m_windowDict.Add(m_windowList[i].TYPE, m_windowList[i]);
                }
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        if(m_windowDict.ContainsKey(UI_TYPE.Loading))
        {
            UIWindow loadingScreen = (UIWindow)m_windowDict[UI_TYPE.Loading];
            if(loadingScreen == null)
            {
                return;
            }
            loadingScreen.Open();
            loadingScreen.SetWindow(sceneName);
        }
    }

    public void SetGameOver(bool isWin)
    {
        if (m_windowDict.ContainsKey(UI_TYPE.GameOver))
        {
            UIWindow gameOverWin = (UIWindow)m_windowDict[UI_TYPE.GameOver];
            if (gameOverWin == null)
            {
                return;
            }

            gameOverWin.Open();

            if(isWin)
            {
                gameOverWin.SetWindow("Win");
            }
            else
            {
                gameOverWin.SetWindow("Lose");
            }

            GameController.instance.OpenNewScene();
        }
    }


    public void EnemyDeadScore()
    {
        if(m_windowDict.ContainsKey(UI_TYPE.Endless))
        {
            if(m_windowDict[UI_TYPE.Endless].isShow())
            {
                m_windowDict[UI_TYPE.Endless].SetWindow();
            }
        }
    }
}
