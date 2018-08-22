using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    private void Awake()
    {
        instance = this;
        bgMusic = this.GetComponent<AudioSource>();
    }

    public AudioSource bgMusic;
    public AudioSource dingBox;
    public AudioSource getSoilder;
    public AudioSource kingDie;
    public AudioSource soilderDie;
    public AudioSource kingActHurt;
    public AudioSource kingArrowHurt;
    public AudioSource soldierActHurt;
    public AudioSource soldierAttack;
    public AudioSource generalAttack;
    public AudioSource laserGun;
    public AudioSource laserKnife;
    public AudioSource stoneMoving;
    public AudioSource archorAttack;

    static Dictionary<string, AudioSource> dict;

    void Start()
    {
        dict = new Dictionary<string, AudioSource>()
        {
            {"dingBox", dingBox },
            {"getSoilder", getSoilder },
            {"kingDie", kingDie },
            {"soilderDie", soilderDie },
            {"kingActHurt", kingActHurt },
            {"kingArrowHurt", kingArrowHurt },
            {"soldierActHurt", soldierActHurt },
            {"soldierAttack", soldierAttack },
            {"generalAttack", generalAttack },
            {"laserGun", laserGun },
            {"laserKnife", laserKnife },
            {"archorAttack", archorAttack },
            {"stoneMoving", stoneMoving }
        };
    }

    

    public void PlaySound(string soundName) 
    {
        if (!dict.ContainsKey(soundName))
        {
            return;
        }

        dict[soundName].Play();
    }

    public void SetBgMusicVolume(float volume)
    {
        bgMusic.volume = volume;
        SetMusicVolumePrefs(volume);
    }

    //设置所有声音
    public void SetSoundVolume(float volume)
    {
        foreach (AudioSource v in dict.Values)
        {
            v.volume = volume;
        }
        SetSoundVolumePrefs(volume);
    }

    //设置单声音
    public void SetSingleVolume(string soundName, float volume)
    {
        if (!dict.ContainsKey(soundName))
        {
            return;
        }
        dict[soundName].volume = volume;
    }

    public void SetMusicVolumePrefs(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSoundVolumePrefs(float volume)
    {
        PlayerPrefs.SetFloat("SoundVolume", volume);
    }

    public float GetMusicVolumePrefs()
    {
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            return 1f;
        }
        return PlayerPrefs.GetFloat("MusicVolume");
    }

    public float GetSoundVolumePrefs()
    {
        if (!PlayerPrefs.HasKey("SoundVolume"))
        {
            return 1f;
        }
        return PlayerPrefs.GetFloat("SoundVolume");
    }


}