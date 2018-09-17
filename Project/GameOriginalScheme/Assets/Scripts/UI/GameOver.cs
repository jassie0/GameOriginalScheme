using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : UIWindow 
{
    public GameObject m_Win;
    public GameObject m_Lose;
    public Text m_Score;

    public override void SetWindow(string data)
    {
        base.SetWindow();
        if(data == "Win")
        {
            m_Win.SetActive(true);
            m_Lose.SetActive(false);
        }
        else if(data == "Lose")
        {
            m_Win.SetActive(false);
            m_Lose.SetActive(true);
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
        Close();        // else
        // {
        //     m_Win.SetActive(false);
        //     m_Lose.SetActive(false);
        //     m_Score.text = "分数：0";
        // }
    }

    private void OnEnable()
    {
        m_Score.text = "金币：" + MoneyManger.Instance().currentGold.ToString();
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
