using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {
	public GameObject pauseMenu;
	public GameObject optionMenu;
	// Use this for initialization
	void Start () {
		pauseMenu.SetActive (false);
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
}
