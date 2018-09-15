using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    //public static SoundManager instance;

    private void Awake()
    {
        //instance = this;
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
	public AudioSource stepPad;
	public AudioSource barMoving;
	public AudioSource spikeOut;
	public AudioSource arrowShoot;
	public AudioSource getCoin;
    public AudioSource startSceneBGM;
    public AudioSource trainingStageBGM;
    public AudioSource stage1BGM;
    public AudioSource stage2BGM;
    public AudioSource successBGM;
    public AudioSource failBGM;
    public AudioSource bossFightBGM;
    public AudioSource buttonClick;
	public AudioSource hitTarget;
	public AudioSource enterStaircase;
	public AudioSource hitEnemy;
	public AudioSource getKey;

    private AudioClip m_tempAudioClip;
    //public AudioClip TempAudioClip{ get{ return m_tempAudioClip; } set{ m_tempAudioClip = value; }}

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
            {"stoneMoving", stoneMoving },
			{"stepPad", stepPad },
			{"barMoving", barMoving },
			{"spikeOut", spikeOut },
			{"arrowShoot", arrowShoot },
			{"getCoin", getCoin },
            {"startSceneBGM",startSceneBGM},
            {"trainingStageBGM",trainingStageBGM},
            {"stage1BGM",stage1BGM},
            {"stage2BGM",stage2BGM},
            {"successBGM",successBGM},
            {"failBGM",failBGM},
            {"bossFightBGM",bossFightBGM},
            {"buttonClick", buttonClick},
			{"hitTarget", hitTarget},
			{"enterStaircase", enterStaircase},
			{"hitEnemy", hitEnemy},
			{"getKey", getKey}

        };
    }



    public void PlayBGM(string bgmName,bool isLoop = true)
    {
        if (!dict.ContainsKey(bgmName))
        {
            return;
        }

        bgMusic.clip = dict[bgmName].clip;
        bgMusic.loop = isLoop;
        bgMusic.Play();
    }

    public void PlayBGMbyClip(AudioClip clip, bool isLoop = true)
    {
        bgMusic.clip = clip;
        bgMusic.loop = isLoop;
        bgMusic.Play();
    }

    public void RecordTempBGM()
    {
        m_tempAudioClip = bgMusic.clip;

    }

    public void PlayTempBGM()
    {
        bgMusic.clip = m_tempAudioClip;
        bgMusic.loop = true;
        bgMusic.Play();
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