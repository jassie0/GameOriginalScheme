using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseOption : UIWindow {

    public Slider m_sound;
    public Slider m_bgMusic;

    void OnEnable()
    {
        m_sound.value = SoundManager.instance.GetSoundVolumePrefs();
        m_bgMusic.value = SoundManager.instance.GetMusicVolumePrefs();
    }

    public void SetSoundVolume()
    {
        SoundManager.instance.SetSoundVolume(m_sound.value);
    }

    public void SetBgMusicVolue()
    {
        SoundManager.instance.SetBgMusicVolume(m_bgMusic.value);
    }

    public void OnClick_Back()
    {
        UIControl.instance.OpenSingleWindow(UI_TYPE.PauseMain);
    }
}
