using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour {
	public Slider Volume;
	public AudioSource music;

	// Update is called once per frame
	void Start () {
		Volume.value = PlayerPrefs.GetFloat ("MusicVolume");
	}

	void Update () {
		music.volume = Volume.value;
	}

	public void VolumePrefs () {
		PlayerPrefs.SetFloat ("MusicVolume", music.volume);
	}
}
