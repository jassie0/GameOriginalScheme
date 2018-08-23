using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMain : UIWindow 
{
    public override void Open()
    {
        base.Open();
        Pause(true);
    }

    public override void Close()
    {
        base.Close();
        Pause(false);
    }

    public void Pause(bool pause)
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

    public void OnClick_Back()
    {
        UIControl.instance.OpenWindow(UI_TYPE.StartPlay);
        GameController.instance.SetInFightScene(false);
    }

    public void OnClick_Option()
    {
        UIControl.instance.OpenWindow(UI_TYPE.PauseOption);
    }

    public void OnClick_Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Close();
    }

    public void OnClick_Resume()
    {
        Close();
    }
}
