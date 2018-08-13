using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//音量系统接口
public interface ISoundSystem : ISystem
{
    //播放声音
    void PlaySound(string soundName);
    //设置所有声音
    void SetAllVolume(float volume);
    //设置单声音
    void SetSingleVolume(string soundName, float volume);
}

public class SoundSystem : ISystem, ISoundSystem
{
    private SoundComponent _soundComponent = null;

    //---------------ISound---------------//
    public void PlaySound(string soundName)
    {
        if (_soundComponent != null)
        {
            _soundComponent.PlaySound(soundName);
        }
    }

    public void SetAllVolume(float volume)
    {
        if (_soundComponent != null)
        {
            _soundComponent.SetAllVolume(volume);
        }
    }

    public void SetSingleVolume(string soundName, float volume)
    {
        if (_soundComponent != null)
        {
            _soundComponent.SetSingleVolume(soundName, volume);
        }
    }

    //---------------ISystem---------------//
    public bool Create()
    {
        GameObject gm = GameObject.Instantiate(Resources.Load(UIConstant.SystemComponent.SoundComponent)) as GameObject;

        if (gm == null)
        {
            return false;
        }

        _soundComponent = gm.GetComponent<SoundComponent>();

        if (_soundComponent == null)
        {
            return false;
        }

        return true;
    }

    public void Release()
    {
        if (_soundComponent != null)
        {
            GameObject.Destroy(_soundComponent.gameObject);
        }
    }

    public void Update()
    {
        
    }

    public void LateUpdate()
    {
        
    }

    public void FixedUpate()
    {
        
    }
}
