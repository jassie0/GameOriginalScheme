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
		//enemy.GetComponent<CharacterHealth> ().EnemyGetHit = false;
		//enemy.GetComponent<CharacterHealth> ().enemyHurtAnim.SetActive (false);
		Destroy(gameObject);

	}

	void GoToHell () {
		Instantiate (transform.parent.gameObject.GetComponent<CharacterHealth> ().coinSpawnPrefab, transform.position, Quaternion.identity);
		Destroy (transform.parent.gameObject);
	}

	void StopShoot () {
		enemy.GetComponent<EnemyShooter> ().enemyAttack = false;
	}

	void ShootLaser () {
        if (enemy.GetComponent<EnemyShooter>().laserPrefab != null) {
            Instantiate(enemy.GetComponent<EnemyShooter>().laserPrefab, this.transform.position, Quaternion.identity);
        }
		
    }

	void SpawnCoins(){
		Instantiate (enemy.GetComponent<CharacterHealth> ().coinSpawnPrefab, transform.position, Quaternion.identity);
	}
}
