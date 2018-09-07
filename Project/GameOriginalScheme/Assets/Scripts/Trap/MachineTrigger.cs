using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineTrigger : MonoBehaviour {
	public Sprite state1;
	public Sprite state2;
	public bool canRestore;
	public bool machineOn = false;
	Sprite barSprite;
	public int hitTime;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void StateChange () {
		hitTime -= 1;
		if (hitTime <= 0) {
			StartCoroutine (Change());
		}
	}

	IEnumerator Change () {
		Debug.Log ("aaaaaa");
		machineOn = !machineOn;
		if (gameObject.GetComponent<SpriteRenderer> ().sprite == state1) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = state2;
		} else if (canRestore == true){
			gameObject.GetComponent<SpriteRenderer> ().sprite = state1;
		} else if (!canRestore) {
			machineOn = !machineOn;
		}
		yield return null;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "King" && gameObject.tag == "Pad") {
			
			if (gameObject.GetComponent<SpriteRenderer> ().sprite == state1) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = state2;
				machineOn = !machineOn;

			} else if (canRestore == true){
				gameObject.GetComponent<SpriteRenderer> ().sprite = state1;
				machineOn = !machineOn;
			}
		}	
	}
}
