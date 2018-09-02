using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineTrigger : MonoBehaviour {
	public Sprite state1;
	public Sprite state2;
	public bool canRestore;
	public bool machineOn = false;
	Sprite barSprite;
	// Use this for initialization
	void Start () {
		barSprite = gameObject.GetComponent<SpriteRenderer> ().sprite;
		barSprite = state1;
	}

	// Update is called once per frame
	void Update () {

	}

	public void StateChange () {
		StartCoroutine (Change());

	}

	IEnumerator Change () {
		Debug.Log ("aaaaaa");
		machineOn = !machineOn;
		if (barSprite == state1) {
			barSprite = state2;
		} else {
			barSprite = state1;
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
