using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UI_TYPE
{
    None,
    StartPlay,
    PauseMain,
    PauseOption

}

public class UIControl : MonoBehaviour
{
    public UIControl instance;

    private void Awake()
    {
        instance = this;
    }

    public List<UIWindow> m_windowList;

    public void F()
    {
        
    }
}
