using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseOption : UIWindow {

    public Slider m_sound;
    public Slider m_bgMusic;

    void OnEnable()
    {
        m_sound.value = SoundManager.Instance().GetSoundVolumePrefs();
        m_bgMusic.value = SoundManager.Instance().GetMusicVolumePrefs();
    }

    public void SetSoundVolume()
    {
        SoundManager.Instance().SetSoundVolume(m_sound.value);
    }

    public void SetBgMusicVolue()
    {
        SoundManager.Instance().SetBgMusicVolume(m_bgMusic.value);
    }

    public void OnClick_Back()
    {
        UIControl.Instance().OpenSingleWindow(UI_TYPE.PauseMain);
    }
     
}
