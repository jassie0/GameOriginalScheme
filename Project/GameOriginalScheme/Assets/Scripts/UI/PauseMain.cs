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
        GameController.Instance().PauseGame(pause);
    }

    public void OnClick_Back()
    {
        UIControl.Instance().OpenSingleWindow(UI_TYPE.StartPlay);
        GameController.Instance().SetInFightScene(true);
        Close();
    }

    public void OnClick_Option()
    {
        UIControl.Instance().OpenSingleWindow(UI_TYPE.PauseOption);

    }

    public void OnClick_Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        UIControl.Instance().CloseAllWindow();
        GameController.Instance().SetInFightScene(true);
        Pause(false);
        Close();
    }

    public void OnClick_Resume()
    {
        GameController.Instance().SetInFightScene(true);
        Pause(false);
        Close();
    }
}
