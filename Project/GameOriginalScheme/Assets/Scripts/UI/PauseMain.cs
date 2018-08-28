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
        GameController.instance.PauseGame(pause);
    }

    public void OnClick_Back()
    {
        UIControl.instance.OpenSingleWindow(UI_TYPE.StartPlay);
        GameController.instance.SetInFightScene(false);
    }

    public void OnClick_Option()
    {
        UIControl.instance.OpenSingleWindow(UI_TYPE.PauseOption);
    }

    public void OnClick_Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        UIControl.instance.CloseAllWindow();
        Close();
    }

    public void OnClick_Resume()
    {
        Close();
    }
}
