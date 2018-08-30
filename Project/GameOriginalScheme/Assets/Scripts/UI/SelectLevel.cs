using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : UIWindow 
{
    public List<Button> m_buttonList;

    private void OnEnable()
    {
        SetLevel();
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

    public void OnClick_LoadLevel1()
    {
        UIControl.instance.LoadScene("SampleScene");
        UIControl.instance.CloseWindow(UI_TYPE.SelectLevel);
        UIControl.instance.OpenWindow(UI_TYPE.TrainingSession);
        UIWindow trainingSession = UIControl.instance.GetWindow(UI_TYPE.TrainingSession);
        if (trainingSession != null)
        {
            trainingSession.SetWindow("MovingTip");
        }

        GameController.instance.SetNowScene(1);

    }
}
