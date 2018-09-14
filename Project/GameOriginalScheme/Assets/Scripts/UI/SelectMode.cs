using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMode : UIWindow 
{
    public void OnClick_StoryMode()
    {
        UIControl.Instance().OpenSingleWindow(UI_TYPE.SelectLevel);
        SoundManager.Instance().PlaySound("buttonClick");
    }

    public void OnClick_OnEndlessMode()
    {
        UIControl.Instance().LoadScene("EndlessMode");
        UIControl.Instance().OpenSingleWindow(UI_TYPE.Endless);
        GameController.Instance().SetInFightScene(true);
        SoundManager.Instance().PlaySound("buttonClick");
        SoundManager.Instance().PlayBGM("bossFightBGM");
    }

}
