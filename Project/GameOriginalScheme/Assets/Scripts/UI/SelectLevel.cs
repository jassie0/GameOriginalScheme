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
        UIControl.Instance().LoadScene("Stage" + i.ToString());
        UIControl.Instance().CloseWindow(UI_TYPE.SelectLevel);
    }

    public void OnClick_LoadLevel1()
    {
        UIControl.Instance().LoadScene("SampleScene");
        UIControl.Instance().CloseWindow(UI_TYPE.SelectLevel);
        UIControl.Instance().OpenWindow(UI_TYPE.Training);
        UIWindow trainingSession = UIControl.Instance().GetWindow(UI_TYPE.Training);
        if (trainingSession != null)
        {
            trainingSession.SetWindow("MovingTip");
        }

        GameController.instance.SetNowScene(1);
    }

    public void OnClick_BossLevel()
    {
        UIControl.Instance().LoadScene("Boss");
        UIControl.Instance().CloseWindow(UI_TYPE.SelectLevel);
    }
}
