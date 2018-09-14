using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenTool : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "King") {
			if (gameObject.tag == "GreenCard") {
				LevelToolValue.greenCardCount += 1;
				LevelToolValue.doorCardCount += 1;
				Destroy (gameObject);
			} else if (gameObject.tag == "Key") {
				SoundManager.Instance ().PlaySound ("getKey");
				LevelToolValue.keyCount += 1;
				Destroy (gameObject);
			} else if (gameObject.tag == "PurpleCard") {
				LevelToolValue.purpleCardCount += 1;
				LevelToolValue.doorCardCount += 1;
				Destroy (gameObject);
			} else if (gameObject.tag == "WhiteCard") {
				LevelToolValue.whiteCardCount += 1;
				LevelToolValue.doorCardCount += 1;
				Destroy (gameObject);
			}
		}
	}
}
