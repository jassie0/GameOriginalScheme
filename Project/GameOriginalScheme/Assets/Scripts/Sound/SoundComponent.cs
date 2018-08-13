using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundComponent : MonoBehaviour {

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

    //播放声音
    public void PlaySound(string soundName) 
    {
        if (!dict.ContainsKey(soundName))
        {
            return;
        }
        dict[soundName].Play();
    }

    //设置所有声音
    public void SetAllVolume(float volume)
    {
        foreach (AudioSource v in dict.Values)
        {
            v.volume = volume;
        }
            
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
}