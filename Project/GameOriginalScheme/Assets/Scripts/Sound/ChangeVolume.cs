using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour {
	public Slider Volume;
	public AudioSource music;
	public AudioSource GetDing;
	public AudioSource getSoldier;
	public AudioSource kingDie;
	public AudioSource soldierDie;
	public AudioSource kingActHurt;
	public AudioSource soldierActHurt;
	public AudioSource kingArrowHurt;
	public AudioSource soldierAttack;
	public AudioSource generalAttack;
	public AudioSource laserGun;
	public AudioSource laserKnife;
	public AudioSource stoneMoving;
	public AudioSource archorAttack;

	void Start () {

		Volume.value = 0.45f;
	}

    //每帧更新音量值，性能会坑啊，我改了，不要觉得我太霸道  --by 杨霜晴
    /*
	void Update () {
		music.volume = Volume.value;
		GetDing.volume = Volume.value;
		getSoldier.volume = Volume.value;
		kingDie.volume = Volume.value;
		soldierDie.volume = Volume.value;
		kingActHurt.volume = Volume.value;
		soldierActHurt.volume = Volume.value;
		kingArrowHurt.volume = Volume.value;
		soldierAttack.volume = Volume.value;
		generalAttack.volume = Volume.value;
		laserGun.volume = Volume.value;
		laserKnife.volume = Volume.value;
		stoneMoving.volume = Volume.value;
		archorAttack.volume = Volume.value;
	}*/

	public void VolumePrefs () {
		PlayerPrefs.SetFloat ("MusicVolume", music.volume);
	}
}
