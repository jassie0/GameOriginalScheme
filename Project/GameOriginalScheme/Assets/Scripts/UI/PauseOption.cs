using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseOption : UIWindow {

    public Slider m_sound;
    public Slider m_bgMusic;

    public void SetSoundVolume()
    {
        SoundManager.instance.SetSoundVolume(m_sound.value);
    }

    public void SetBgMusicVolue()
    {
        SoundManager.instance.SetBgMusicVolume(m_bgMusic.value);
    }
}
