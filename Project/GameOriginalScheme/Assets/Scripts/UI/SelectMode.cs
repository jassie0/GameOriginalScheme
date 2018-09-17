using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMode : UIWindow 
{
    public void OnClick_StoryMode()
    {
        SoundManager.Instance().PlaySound("buttonClick");
        UIControl.Instance().OpenSingleWindow(UI_TYPE.SelectLevel);
    }

    public void OnClick_OnEndlessMode()
    {
        UIControl.Instance().LoadScene("EndlessMode");
        GameController.Instance().SetInFightScene(true);
        SoundManager.Instance().PlaySound("buttonClick");
        SoundManager.Instance().PlayBGM("bossFightBGM");
        UIControl.Instance().OpenSingleWindow(UI_TYPE.Endless);
    }

}
