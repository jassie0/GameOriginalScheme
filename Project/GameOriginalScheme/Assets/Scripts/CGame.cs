using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//新建系统必须继承该接口
public interface ISystem
{
    bool Create();
    void Release();
    void Update();
    void LateUpdate();
    void FixedUpate();
}

/// <summary>
/// 游戏主控制器，全局单例
/// </summary>
public class CGame 
{
    //---------------单例---------------//
    private static CGame _instance;
    public static CGame Instance
    {
        get
        {
            if (_instance == null)
                _instance = new CGame();
            return _instance;
        }
    }

    //---------------各系统模块声明---------------//

    //声音管理系统
    ISoundSystem _soundSystem = null;
    

    //---------------取得各模块---------------//

    //声音管理系统
    public ISoundSystem SoundSystem { get { return _soundSystem; } }


    //初始化
    public void Create()
    {
        _soundSystem.Create();
    }

    //释放
    public void Release()
    {
        _soundSystem.Release();
    }

    public void Update()
    { }

    public void FixedUpdate()
    { }

    public void LateUpdate()
    { }
}

//各系统预制体位置
public class UIConstant
{
    //系统组件位置
    public struct SystemComponent
    {
        //音量调节组件
        public static readonly string SoundComponent = "Prefabs/Component/SoundComponent";

    }

    //UI组件位置
    public struct Window
    {
        //UI画布
        public static readonly string Canvas = "PrefabPath/UI/Canvas";
    }
}



