using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	public GameObject platform;
	public float movingSpeed;
	public Transform currentPoint;
	public Transform[] points;
	public int pointSelection;
	public GameObject[] platformController;
	// Use this for initialization
	void Start () {
		currentPoint = points[pointSelection];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		for(int i = 0; i < platformController.Length; i++){
			if (platformController[i].GetComponent<MachineTrigger>().machineOn == true) {
				platform.transform.position = Vector3.MoveTowards (platform.transform.position, currentPoint.position, Time.deltaTime * movingSpeed);

				if (platform.transform.position == currentPoint.position){
					pointSelection++;

					if (pointSelection == points.Length){
						pointSelection = 0;
					}
					currentPoint = points[pointSelection];
				}
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "King") {
			other.transform.parent = transform;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "King") {
			other.transform.parent = null;
		}
	}
}
