using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour {
	public GameObject target;
	public float movingSpeed;
	public Transform currentPoint;
	public Transform[] points;
	public int pointSelection;
	// Use this for initialization
	void Start () {
		currentPoint = points[pointSelection];
	}
	
	// Update is called once per frame
	void Update () {
		target.transform.position = Vector3.MoveTowards (target.transform.position, currentPoint.position, Time.deltaTime * movingSpeed);

		if (target.transform.position == currentPoint.position){
			pointSelection++;

			if (pointSelection == points.Length){
				pointSelection = 0;
			}
			currentPoint = points[pointSelection];
		}

		if (GetComponent<MachineTrigger> ().machineOn) {
			movingSpeed = 0;
		}
	}
}
