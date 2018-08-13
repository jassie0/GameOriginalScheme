using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIComponent : MonoBehaviour
{
    [System.Serializable]
    public class WindowModelConfig
    {
        public WindowModel model;
        public UIWindow window;
    }

    public List<WindowModelConfig> windowPrefabList;
    private List<UIWindow> visiableWindow;

    public void Show(WindowModel model)
    {
        foreach (UIWindow w in visiableWindow)
        {
            if (w.windowModel == model)
            {
                w.gameObject.SetActive(true);
            }
        }
    }

    public void Hide(WindowModel model)
    {
        foreach (UIWindow w in visiableWindow)
        {
            if (w.windowModel == model)
            {
                w.gameObject.SetActive(false);
            }
        }
    }

    public void CreateWindow(WindowModel model)
    {
        foreach (WindowModelConfig a in windowPrefabList)
        {
            if (a.model == model)
            {
                UIWindow uiWindow = Instantiate(a.window.gameObject).GetComponent<UIWindow>();
                visiableWindow.Add(uiWindow);
            }
        }
    }

    public void DestroyWindow(WindowModel model)
    {
        foreach (WindowModelConfig a in windowPrefabList)
        {
            if (a.model == model)
            {
                UIWindow uiWindow = a.window;
                visiableWindow.Remove(uiWindow);
                GameObject.Destroy(uiWindow.gameObject);
            }
        }
    }
}
