using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : UIWindow 
{
    public GameObject m_Win;
    public GameObject m_Lose;
    public GameObject m_Over;
    public Text m_Score;

    public override void SetWindow(string data)
    {
        base.SetWindow();
        if(data == "Win")
        {
            m_Win.SetActive(true);
            m_Lose.SetActive(false);
            m_Over.SetActive(false);
        }
        else if(data == "Lose")
        {
            m_Win.SetActive(false);
            m_Lose.SetActive(true);
            m_Over.SetActive(false);
        }
        else
        {
            m_Win.SetActive(false);
            m_Lose.SetActive(false);
            m_Over.SetActive(true);
            m_Score.text = "分数：" + data;
        }
    }

    public void OnClick_Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SoundManager.Instance().PlayTempBGM();
        Close();
    }

    public void OnClick_BackTo()
    {
        UIControl.Instance().OpenSingleWindow(UI_TYPE.StartPlay);
        GameController.Instance().SetInFightScene(false);
        SoundManager.Instance().PlayBGM("startSceneBGM");
        Close();
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
