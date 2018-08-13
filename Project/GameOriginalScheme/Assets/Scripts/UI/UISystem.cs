using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUISystem : ISystem
{
    void ShowWindow(WindowModel windowModel);
    void HideWindow(WindowModel windowModel);
    void CreateWindow(WindowModel windowModel);
    void DestoryWindow(WindowModel windowModel);
}

public class UISystem : IUISystem
{
    private GameObject _canvas;


    public void CreateWindow(WindowModel windowModel)
    {
        
    }

    public void DestoryWindow(WindowModel windowModel)
    {
        
    }

    public void HideWindow(WindowModel windowModel)
    {
        
    }

    public void ShowWindow(WindowModel windowModel)
    {
        
    }

    public bool Create()
    {
        GameObject instance = GameObject.Instantiate(Resources.Load<GameObject>(UIConstant.Window.Canvas));
        return true;
    }

    public void Release()
    {
        if (_canvas != null)
        {
            GameObject.Destroy(_canvas);
        }
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }

    public void LateUpdate()
    {
        throw new System.NotImplementedException();
    }

    public void FixedUpate()
    {
        throw new System.NotImplementedException();
    }
}

