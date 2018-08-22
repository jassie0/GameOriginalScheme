using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UIWindow : MonoBehaviour {

    public UI_TYPE m_type;

    public void InitType(UI_TYPE type)
    {
        m_type = type;
    }

    public virtual void OpenWindow()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void CloseWindow()
    {
        this.gameObject.SetActive(false);
    }
}
