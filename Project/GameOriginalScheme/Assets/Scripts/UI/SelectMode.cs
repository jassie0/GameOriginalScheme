using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMode : UIWindow 
{
    public void OnClick_StoryMode()
    {
        UIControl.instance.OpenSingleWindow(UI_TYPE.SelectLevel);
    }

    public void OnClick_OnEndlessMode()
    {
        UIControl.instance.LoadScene("EndlessMode");
        UIControl.instance.OpenSingleWindow(UI_TYPE.Endless);
        GameController.instance.SetInFightScene(true);
    }

}
