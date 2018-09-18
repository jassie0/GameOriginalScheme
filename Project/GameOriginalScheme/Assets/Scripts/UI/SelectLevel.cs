using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : UIWindow 
{
    public List<Button> m_buttonList;
    public Button m_bossLevel;

    private void OnEnable()
    {
        //SetLevel();
    }

    private void SetLevel()
    {
        int level = PlayerPrefs.GetInt("Level");

        for (int i = 0; i < m_buttonList.Count; i++)
        {
            if(i < level)
            {
                m_buttonList[i].gameObject.SetActive(true);
            }
            else
            {
                m_buttonList[i].gameObject.SetActive(false);
            }
        }
    }

    public void OnClick_LoadLevel(int i)
    {
        MoneyManger.Instance().ResetGold();
        UIControl.Instance().LoadScene("Stage" + i.ToString());
        UIControl.Instance().CloseWindow(UI_TYPE.SelectLevel);
        if(0 == i)
        {
            SoundManager.Instance().PlayBGM("trainingStageBGM");
        }
        else if(1 == i)
        {
            SoundManager.Instance().PlayBGM("stage1BGM");
        }
        else if(2 == i)
        {
            SoundManager.Instance().PlayBGM("stage2BGM");
        }
    }

    public void OnClick_LoadLevel1()
    {
        MoneyManger.Instance().ResetGold();
        UIControl.Instance().LoadScene("SampleScene");
        UIControl.Instance().CloseWindow(UI_TYPE.SelectLevel);
        UIControl.Instance().OpenWindow(UI_TYPE.Training);
        UIWindow trainingSession = UIControl.Instance().GetWindow(UI_TYPE.Training);
        if (trainingSession != null)
        {
            trainingSession.SetWindow("MovingTip");
        }

        GameController.Instance().SetNowScene(1);
    }

    public void OnClick_BossLevel()
    {
        UIControl.Instance().LoadScene("Boss");
        UIControl.Instance().CloseWindow(UI_TYPE.SelectLevel);
        SoundManager.Instance().PlayBGM("bossFightBGM");
    }
}
