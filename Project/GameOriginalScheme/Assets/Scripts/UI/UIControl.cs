using System.Collections;
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
    Training,
    MovingTips
}

[System.Serializable]
public class Window
{
    public UIWindow window;
    public UI_TYPE type;
}

public class UIControl : MonoSingleton<UIControl>
{
    public List<Window> m_windowList;

    //[HideInInspector]
    //public static UIControl instance;

    //private void Awake()
    //{
    //    instance = this;
    //}

    private void Start()
    {
        OpenSingleWindow(UI_TYPE.StartPlay);
    }

    private static Dictionary<UI_TYPE, UIWindow> m_windowDict = new Dictionary<UI_TYPE, UIWindow>();
    private static List<UIWindow> m_alwaysTopWindowList = new List<UIWindow>();

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
        if (m_windowDict.ContainsKey(type))
        {
            m_windowDict[type].Open();
        }
        else
        {
            UIWindow win = CreateWindow(type);
            if (win != null)
            {
                win.Open();
            }
        }

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

        CheckTopWindow();
    }

    public void CloseWindow(UI_TYPE type)
    {
        if (m_windowDict.ContainsKey(type))
        {
            UIWindow window = m_windowDict[type];
            if (window != null)
            {
                m_windowDict[type].Close();
            }
            else
            {
                m_windowDict.Remove(type);
            }
        }
    }

    public void OpenWindow(UI_TYPE type)
    {
        if (m_windowDict.ContainsKey(type))
        {
            m_windowDict[type].Open();
        }
        else
        {
            UIWindow win = CreateWindow(type);
            if (win != null)
            {
                win.Open();
            }
        }
        CheckTopWindow();
    }

    public UIWindow CreateWindow(UI_TYPE type)
    {
        if (m_windowDict.ContainsKey(type))
        {
            return m_windowDict[type];
        }
        else
        {
            for (int i = 0; i < m_windowList.Count; i++)
            {
                if (m_windowList[i].type == type)
                {
                    GameObject win = Instantiate(m_windowList[i].window.gameObject, transform);
                    if (win != null)
                    {
                        UIWindow UIwindow = win.GetComponent<UIWindow>();
                        if (UIwindow != null)
                        {
                            m_windowDict.Add(type, UIwindow);
                            CheckTopWindow();
                            return UIwindow;
                        }
                    }
                }
            }
            return null;
        }
    }

    public void DestroyWindow(UI_TYPE type)
    {
        if (m_windowDict.ContainsKey(type))
        {
            UIWindow window = m_windowDict[type];
            if (window != null)
            {
                Destroy(window);
            }
            m_windowDict.Remove(type);
        }
    }

    public void SetWindowAlwaysTop(UIWindow window)
    {
        if (window != null)
        {
            m_alwaysTopWindowList.Add(window);
        }
    }

    private void CheckTopWindow()
    {
        for (int i = 0; i < m_alwaysTopWindowList.Count; i++)
        {
            m_alwaysTopWindowList[i].transform.SetAsLastSibling();
        }
    }

    //---------------以下为窗口逻辑----------------//

    public void LoadScene(string sceneName)
    {
        UIWindow loadingWindow = CreateWindow(UI_TYPE.Loading);
        if (loadingWindow != null)
        {
            SetWindowAlwaysTop(loadingWindow);
            loadingWindow.Open();
            loadingWindow.SetWindow(sceneName);
        }
    }

    public void SetGameOver(bool isWin)
    {
        UIWindow gameOverWin = CreateWindow(UI_TYPE.GameOver);
        if (gameOverWin == null)
        {
            return;
        }

        gameOverWin.Open();

        if(isWin)
        {
            gameOverWin.SetWindow("Win");
            SoundManager.Instance().RecordTempBGM();
            SoundManager.Instance().PlayBGM("successBGM", false);
        }
        else
        {
            gameOverWin.SetWindow("Lose");
            SoundManager.Instance().RecordTempBGM();
            SoundManager.Instance().PlayBGM("failBGM", false);
        }

        GameController.Instance().OpenNewScene();
    }


    public void EnemyDeadScore()
    {
        UIWindow endlessWin = GetWindow(UI_TYPE.Endless);
        if (endlessWin == null)
        {
            return;
        }

        if (endlessWin.isShow())
        {
            m_windowDict[UI_TYPE.Endless].SetWindow();
        }
    }

    public void SetScore(int money)
    {
        UIWindow endlessWin = GetWindow(UI_TYPE.Endless);
        if (endlessWin == null)
        {
            return;
        }

        if (endlessWin.isShow())
        {
            m_windowDict[UI_TYPE.Endless].SetWindow(money.ToString());
        }
    }

    public void TrainingMassage(string massage)
    {
        UIWindow teachWindow = CreateWindow(UI_TYPE.Training);
        if (teachWindow == null)
        {
            return;
        }
        teachWindow.SetWindow(massage);
    }
}
