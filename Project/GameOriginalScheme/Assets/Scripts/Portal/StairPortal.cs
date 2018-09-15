using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairPortal : MonoBehaviour {
	public GameObject Portal;
	GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("King");
	}

	public void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "King"){
			StartCoroutine (Teleport());
		}
	}

	IEnumerator Teleport () {
		yield return new WaitForSeconds (0.15f);
		SoundManager.Instance ().PlaySound ("enterStaircase");
		player.transform.position = new Vector2 (Portal.transform.position.x, Portal.transform.position.y);
	}
}
