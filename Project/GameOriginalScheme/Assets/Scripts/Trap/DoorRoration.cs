using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRoration : MonoBehaviour {
	Animator colliderAnim;
	Animator doorAnim;
	public Transform doorCollider;
	public GameObject doorSprite;
	public GameObject[] activator;
	bool doorOpen;
	// Use this for initialization
	void Start () {
		colliderAnim = doorCollider.GetComponent<Animator> ();
		doorAnim = doorSprite.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < activator.Length; i++) {
			if (activator[i].GetComponent<MachineTrigger> ().machineOn == true) {
				if (!doorOpen) {
					colliderAnim.SetTrigger ("OpenDoor");
					doorAnim.SetTrigger ("Open");
					activator [i].GetComponent<MachineTrigger> ().machineOn = false;
					doorOpen = true;
				} else {
					colliderAnim.SetTrigger ("CloseDoor");
					doorAnim.SetTrigger ("Close");
					activator [i].GetComponent<MachineTrigger> ().machineOn = false;
					doorOpen = false;
				}
			} 
		}
	}
		
}
