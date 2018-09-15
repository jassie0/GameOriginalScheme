using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenRoom : MonoBehaviour {
	public float transparency = 0.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "King") {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, transparency);
		}
	}
}
