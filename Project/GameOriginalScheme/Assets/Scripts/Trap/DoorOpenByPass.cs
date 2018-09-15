using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenByPass : MonoBehaviour {
	public bool OpenRange;
	public bool doorMoving;
	public Transform currentPoint;
	public float movingSpeed;
	public int pointSelection;
	public Transform[] points;
	public GameObject door;
	public GameObject textTip;
	public GameObject doorOpenLight;
	TextMesh tip;
	// Use this for initialization
	void Start () {
		currentPoint = points[pointSelection];
		textTip.SetActive (false);
		tip = textTip.GetComponent<TextMesh> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && OpenRange) {
			if (gameObject.tag == "GreenDoor") {
				if (LevelToolValue.greenCardCount > 0) {
					doorMoving = true;
				} else {
					tip.text = "需要绿色房卡开门";
				}
			} else if (gameObject.tag == "KeyDoor") {
				if (LevelToolValue.keyCount > 0) {
					doorMoving = true;
					LevelToolValue.keyCount -= 1;
				} else {
					tip.text = "需要钥匙开门";
				}
			} else if (gameObject.tag == "PurpleDoor") {
				if (LevelToolValue.purpleCardCount > 0) {
					doorMoving = true;
				} else {
					tip.text = "需要紫色房卡开门";
				}
			} else if (gameObject.tag == "WhiteDoor") {
				if (LevelToolValue.whiteCardCount > 0) {
					doorMoving = true;
				} else {
					tip.text = "需要白色房卡开门";
				}
			} else if (gameObject.tag == "CommonDoor"){
				doorMoving = true;
			} else if (gameObject.tag == "BossDoor"){
				if (LevelToolValue.whiteCardCount > 0 && LevelToolValue.purpleCardCount > 0 && LevelToolValue.greenCardCount > 0 ) {
					doorMoving = true;
				} else {
					tip.text = "房卡未集齐";
				}
			}
		}
		if (doorMoving) {
			door.transform.position = Vector3.MoveTowards (door.transform.position, points [0].position, Time.deltaTime * movingSpeed);
			textTip.SetActive (false);
			doorOpenLight.SetActive (true);
			//doorMoving = false;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "King") {
			textTip.SetActive (true);
			tip.text = "按下 空格 开门";
			Debug.Log (LevelToolValue.doorCardCount);
			OpenRange = true;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "King") {
			textTip.SetActive (false);
			OpenRange = false;
		}
	}
}
