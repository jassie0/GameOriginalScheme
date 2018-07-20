using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAttack : MonoBehaviour {
	public Transform arrowPrefab;
	public float interval = 1.5f;
	public float arrowSpeed = 5f;
	//public Transform arrow;
	// Use this for initialization
	void Start () {
		 //arrow= Instantiate(arrowPrefab, this.transform.position, this.transform.rotation, this.transform.parent);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.W)) {
			StartCoroutine (ShootArrow());
		}
	}

	IEnumerator ShootArrow() {
		Transform arrow= Instantiate(arrowPrefab, this.transform.position, this.transform.rotation, this.transform.parent);
		arrow.GetComponent<Arrow>().speed = arrowSpeed;
		yield return null;
		//StartCoroutine(ShootArrow());

	}
}
