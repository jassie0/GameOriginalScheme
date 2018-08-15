using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {
	public GameObject pauseMenu;
	public GameObject optionMenu;
    public Slider m_sound;
    public Slider m_bgMusic;

    //public bool m_isSoundInited = true;

	// Use this for initialization
	void Start () {
		pauseMenu.SetActive (false);

        m_sound.value = SoundManager.instance.GetSoundVolumePrefs();
        m_bgMusic.value = SoundManager.instance.GetMusicVolumePrefs();
        //if (!m_isSoundInited)
        {


            //m_isSoundInited = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (!optionMenu.activeSelf) {
				pauseMenu.SetActive (true);
				Time.timeScale = 0;
			}
		}
	}

	public void ResumeGame() {
		pauseMenu.SetActive (false);
		Time.timeScale = 1;
	}

    public void SetSoundVolume()
    {
        //if (m_isSoundInited)
        {
            SoundManager.instance.SetSoundVolume(m_sound.value);
        }
        
    }

    public void SetBgMusicVolue()
    {
        //if (m_isSoundInited)
        {
            SoundManager.instance.SetBgMusicVolume(m_bgMusic.value);
        }
    }
}
