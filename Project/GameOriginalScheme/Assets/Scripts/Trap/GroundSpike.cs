using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpike : MonoBehaviour {
	public float interval = 1.5f;
	public Transform spikePrefab;
	public bool checkRun = true;
	public GameObject[] skikeActivator;

	// Use this for initialization
	void Start () {
		interval = spikePrefab.GetComponent<DistoryThisAfterAWhile> ().m_Time * 2;
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < skikeActivator.Length; i++) {
			if (skikeActivator[i].GetComponent<MachineTrigger> ().machineOn == true && checkRun == true) {
				StartCoroutine (SkikeShowUp());
				checkRun = false;
			} else if (skikeActivator[i].GetComponent<MachineTrigger> ().machineOn == false) {
				StopAllCoroutines ();
				checkRun = true;
			}
		}
	}

	IEnumerator SkikeShowUp() {
		Instantiate(spikePrefab, transform.position, spikePrefab.rotation, this.transform.parent);
		yield return new WaitForSeconds(interval);
		StartCoroutine(SkikeShowUp());
	}
}
