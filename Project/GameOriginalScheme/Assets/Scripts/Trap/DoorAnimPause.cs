using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimPause : MonoBehaviour {
	Animator anim;
	void Start() {
		anim = GetComponent<Animator> ();
	}

	void PauseAnim () {
		//anim.enabled = false;
	}
	
}
