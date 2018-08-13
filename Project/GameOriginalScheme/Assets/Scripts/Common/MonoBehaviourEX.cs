using UnityEngine;
using System.Collections;

//简化版单例，返回实例可能为空，需要执行负责实例的创建（调用前，保证场景中存在带该脚本的GameObject），会随着场景的销毁而销毁
public class MonoBehaviourEX<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _Instance;
    public static T Instance
    {

        get
        {
//为方便编辑器中使用，这里在编辑器模式下（非运行模式）手动查找场景中的实例
#if UNITY_EDITOR
            if (_Instance == null)
            {
                T instanceInScene = GameObject.FindObjectOfType<T>();
                if (instanceInScene != null)
                {
                    _Instance = instanceInScene;
                }
            }
#endif
            return _Instance;
        }
    }



    public virtual void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this as T;
        }
        //可能在Awake之前已经调用过单例，所以需要判断_Instance是否为当前实例
        else if (!_Instance.Equals(this))
        {
            Debug.Log("You already have a instance of " + typeof(T).ToString() + ";The new one will be destoryed");
            if (Application.isPlaying)
            {
                Destroy(this);
            }
            else
            {
                DestroyImmediate(this);
            }
        } 
    }
}

