using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineTrigger : MonoBehaviour {
	public Sprite state1;
	public Sprite state2;
	public bool canRestore;
	public bool machineOn = false;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer> ().sprite = state1;
	}

	// Update is called once per frame
	void Update () {

	}

	public void StateChange () {
		Debug.Log ("aaa");
		machineOn = !machineOn;
//		if (gameObject.GetComponent<SpriteRenderer> ().sprite == state1) {
//			gameObject.GetComponent<SpriteRenderer> ().sprite = state2;
//		} else {
//			gameObject.GetComponent<SpriteRenderer> ().sprite = state1;
//		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "King" && gameObject.tag == "Pad") {
			machineOn = !machineOn;
			if (gameObject.GetComponent<SpriteRenderer> ().sprite == state1) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = state2;

			} else if (canRestore == true){
				gameObject.GetComponent<SpriteRenderer> ().sprite = state1;

			}
		}	
	}
}
