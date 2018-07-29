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

	// Update is called once per frame
	void Start () {
		Volume.value = PlayerPrefs.GetFloat ("MusicVolume");
	}

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

	}

	public void VolumePrefs () {
		PlayerPrefs.SetFloat ("MusicVolume", music.volume);
	}
}
