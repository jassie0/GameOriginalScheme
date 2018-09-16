using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicalDoor : MonoBehaviour {
	public GameObject[] activator;
	public Transform currentPoint;
	public float movingSpeed;
	public bool doorMoving;
	public bool checkChange;
	public int pointSelection;
	public Transform[] points;
	public GameObject door;
	// Use this for initialization
	void Start () {
		currentPoint = points[pointSelection];
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < activator.Length; i++) {
			if (activator [i].GetComponent<MachineTrigger> ().machineOn) {
				//checkChange = activator [i].GetComponent<MachineTrigger> ().machineOn;
				doorMoving = true;
				if (doorMoving) {
					door.transform.position = Vector3.MoveTowards (door.transform.position, points[0].position, Time.deltaTime * movingSpeed);
					if (transform.position == currentPoint.position) {
						doorMoving = false;
					}
				}
				if (GetComponent<DoorOpenByPass> () != null){
					GetComponent<DoorOpenByPass> ().textTip.SetActive (false);
					GetComponent<DoorOpenByPass> ().doorOpenLight.SetActive (true);
				}


			} else {
				if (doorMoving) {
					door.transform.position = Vector3.MoveTowards (door.transform.position, points [1].position, Time.deltaTime * movingSpeed);
						if (transform.position == currentPoint.position) {
						doorMoving = false;
					}
				}
			} 
		}
	}
}
