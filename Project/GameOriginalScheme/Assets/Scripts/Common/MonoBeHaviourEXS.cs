using UnityEngine;
using System.Collections;

//强化版单例（安全模式），不论如何使用，返回实例都不会为空,建议全局管理类使用；如果有序列化属性，需要手动添加到场景,不会随场景销毁而销毁
public class MonoBehaviourEXS<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _Instance;
    public static T Instance
    {

        get
        {
            if (_Instance == null)
            {
                T instanceInScene = GameObject.FindObjectOfType<T>();
                if (instanceInScene != null)
                {
                    Debug.LogWarning("It will be better if you set the excution order of " + typeof(T).ToString() + " before other script using it");
                    GameObject.FindObjectOfType<T>().SendMessage("Awake");
                    DontDestroyOnLoad(_Instance.gameObject);
                }
                else
                {
                    //如果脚本有在inspector进行设置，那么本次调用这些设置将丢失
                    Debug.LogWarning(typeof(T).ToString() + "havn't be added to sence, we will create a tmp one,that may cause some problem.");
                    GameObject singleton = new GameObject();
                    singleton.hideFlags = HideFlags.HideAndDontSave;
                    _Instance = singleton.AddComponent<T>();

                }

            }
            return _Instance;
        }
    }



    public virtual void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (!_Instance.Equals(this))
        {
            if (HideFlags.HideAndDontSave.Equals(_Instance.gameObject.hideFlags))
            {
                Destroy(_Instance.gameObject);
                _Instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Debug.LogWarning("You already have a instance of " + typeof(T).ToString() + ";The new one will be destoryed");
                Destroy(this);
            }
        }
    }
}
