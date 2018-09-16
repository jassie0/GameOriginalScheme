using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpike : MonoBehaviour {
	public float interval = 1.5f;
	public Transform spikePrefab;
	public bool checkRun = true;
	public GameObject[] skikeActivator;

	public float m_soundDistance = 12;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = PlayerController.GetPlayerObject();
		interval = spikePrefab.GetComponent<DistoryThisAfterAWhile> ().m_Time * 2;
		if (skikeActivator.Length == 0) {
			StartCoroutine (SkikeShowUp());
		}
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
		if(player != null)
		{
			float Distance = Vector2.Distance((Vector2)transform.position, (Vector2)player.transform.position);
			if(Distance < m_soundDistance)
			{
				SoundManager.Instance().PlaySound("spikeOut");
			}
		}
		yield return new WaitForSeconds(interval);
		StartCoroutine(SkikeShowUp());
	}
}
