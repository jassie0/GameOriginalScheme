using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WindowModel
{
    None = -1,
    StartPlay,        
    PauseMain,          
    PauseOption         
}

public class UIWindow : MonoBehaviour
{
    public WindowModel windowModel;

    public virtual void ShowWindow()
    {
        //UIManager.Instance.ShowWindow(this.gameObject);
    }

    public virtual void HideWindow(bool destory = false)
    {
        //UIManager.Instance.HideWindow(this.gameObject);
        //if (destory)
        //{
        //    UIManager.Instance.DestoryWindow(this.gameObject);
        //}
    }

    public virtual void CreateWindow()
    {

    }

    public virtual void DestroyWindow()
    {
        //UIManager.Instance.DestoryWindow(this.gameObject);
    }

    /// <summary>
    /// gameObject 是否被激活
    /// </summary>
    /// <returns></returns>
    public virtual bool isShow()
    {
        return gameObject.activeSelf;
    }

    /// <summary>
    /// gameObject是否被显示在Hierarchy列表上
    /// </summary>
    /// <returns></returns>
    public virtual bool isShowHierarchy()
    {
        return gameObject.activeInHierarchy;
    }


}
