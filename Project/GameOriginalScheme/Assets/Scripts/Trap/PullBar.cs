using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullBar : MonoBehaviour {
	public Sprite UpState;
	public Sprite DownState;
	public bool machineOn;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer> ().sprite = UpState;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StateChange () {
		if (gameObject.GetComponent<SpriteRenderer> ().sprite == UpState) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = DownState;
			machineOn = true;
		}else if (gameObject.GetComponent<SpriteRenderer> ().sprite == DownState) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = UpState;
			machineOn = false;
		}
	}
}
