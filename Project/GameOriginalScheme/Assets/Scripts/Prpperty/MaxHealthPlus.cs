using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthPlus : MonoBehaviour {
	public GameObject[] soldiers;
	// Use this for initialization
	void Start () {
		for(int i = 0; i < soldiers.Length; i ++){
			soldiers [i].GetComponent<CharacterHealth> ().maxHealth = soldiers [i].GetComponent<CharacterHealth> ().originalHealth;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "King") {
			for(int i = 0; i < soldiers.Length; i ++){
				soldiers [i].GetComponent<CharacterHealth> ().maxHealth += soldiers [i].GetComponent<CharacterHealth> ().healthPlus;
			}

			Destroy(this.gameObject);
		}
	}
}
