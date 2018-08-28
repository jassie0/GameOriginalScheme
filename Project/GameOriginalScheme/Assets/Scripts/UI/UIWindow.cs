using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UIWindow : MonoBehaviour 
{
    public UI_TYPE TYPE;
    //public UI_TYPE TYPE { get { return m_type; } set { m_type = value; }}

    public virtual void Open()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void Close()
    {
        this.gameObject.SetActive(false);
    }

    public virtual void SetWindow()
    {
        
    }

    public virtual void SetWindow(string data)
    {
        
    }

    public virtual bool isShow()
    {
        return this.gameObject.activeSelf;
    }
}
