using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrap : MonoBehaviour {
	public GameObject trapOn;
	public GameObject trapOff;
	public GameObject trapActivator;
	public float time = 0;
	public float trapOnTime;
	// Use this for initialization
	void Start () {
		trapOn.SetActive (false);
		trapOff.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (trapActivator.GetComponent<PullBar> ().machineOn == true) {
			//StartCoroutine (TrapShowUp());
			if (time < trapOnTime) {
				trapOn.SetActive (true);
				//time++;
			} else {
				trapOn.SetActive (false);
				time = 0;
			}

		} else {
			trapOn.SetActive (false);
		}
	}

//	IEnumerator TrapShowUp() {
//		while(true) {
//			trapOn.SetActive (true);
//			yield return new WaitForSeconds (1f);
//			trapOn.SetActive (false);
//		}
//
//
//	}

}
