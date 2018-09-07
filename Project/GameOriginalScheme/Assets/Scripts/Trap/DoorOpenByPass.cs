using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenByPass : MonoBehaviour {

	public bool NeedForCard;
	public bool NeedForKey;
	public bool OpenRange;
	public bool doorMoving;
	public Transform currentPoint;
	public float movingSpeed;
	public int pointSelection;
	public Transform[] points;
	public GameObject door;
	public GameObject textTip;
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
			if (NeedForCard) {
				if (LevelToolValue.doorCardCount > 0) {
					doorMoving = true;
					LevelToolValue.doorCardCount -= 1;
				} else {
					tip.text = "需要房卡开门";
				}
			} else if (NeedForKey) {
				if (LevelToolValue.keyCount > 0) {
					doorMoving = true;
					LevelToolValue.keyCount -= 1;
				} else {
					tip.text = "需要钥匙开门";
				}
			} else if (!NeedForKey && !NeedForCard) {
				doorMoving = true;
			}
		}
		if (doorMoving) {
			door.transform.position = Vector3.MoveTowards (door.transform.position, points [0].position, Time.deltaTime * movingSpeed);
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
