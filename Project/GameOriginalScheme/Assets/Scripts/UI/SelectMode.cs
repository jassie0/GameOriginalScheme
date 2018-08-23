using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMode : UIWindow 
{
    public void OnClick_StoryMode()
    {
        UIControl.instance.OpenWindow(UI_TYPE.SelectLevel);
    }

    public void OnClick_OnEndlessMode()
    {
        Debug.Log("开发中。。。。");
    }

}
