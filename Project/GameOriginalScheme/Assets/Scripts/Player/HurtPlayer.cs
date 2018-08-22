using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {
	public float coolDownTime;

	public float startTime;

	public Transform startPos;
	public Transform endPos;
	public LayerMask enemies;
	public float damage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GiveDamage () {
		Collider2D[] enemiesToDamage = Physics2D.OverlapAreaAll (startPos.position, endPos.position, enemies);

		for (int i = 0; i < enemiesToDamage.Length; i++) {

			enemiesToDamage [i].GetComponent<CharacterHealth> ().TakeDamage (damage);
		}
	}


}
