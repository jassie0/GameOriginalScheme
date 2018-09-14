using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndEnemyHurtAnim : MonoBehaviour {

	Animator anim;
	public GameObject enemy;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void EndAnim () {
		enemy.GetComponent<CharacterHealth> ().EnemyGetHit = false;
		//enemy.GetComponent<CharacterHealth> ().enemyHurtAnim.SetActive (false);
	}
}
