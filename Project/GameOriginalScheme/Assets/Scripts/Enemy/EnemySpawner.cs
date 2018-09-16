using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	//public GameObject MeleeEnemyPrefab;

	public Vector2 center;

	//private Vector2 center;
	public Vector2 size;

	public GameObject[] enemies;
	//public Vector2 spawnValues;
	private float spawnWait;
	public float spawnFirstWait;
	public float spawnSecondWait;
	public int startWait;
	public bool stop;
	public int spawnTime = 0;
	//public Vector2 detectRange;
	//public LayerMask players;

	int randomEnemy;


	// Use this for initialization
	void Start () {
//		Collider2D[] player = Physics2D.OverlapBoxAll (center, detectRange, 90f, players);
//		if (player.Length > 0) {
//			spawnWait = spawnFirstWait;
//			StartCoroutine (SpawnerWait ());
//		}
		//center = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnTime >= 2) {
			stop = true;
			Destroy (gameObject);
		} 
	}
		

	IEnumerator SpawnerWait() {
		yield return new WaitForSeconds (startWait);
		while (!stop){
			randomEnemy = Random.Range (0, enemies.Length);

			Vector2 spawnPosition = center + new Vector2 (Random.Range(-size.x/2, size.x /2), Random.Range(-size.y/2, size.y/2));
			Instantiate (enemies[randomEnemy], spawnPosition, Quaternion.identity);

			yield return new WaitForSeconds (spawnWait);
			spawnTime = spawnTime + 1;
			spawnWait = spawnSecondWait;
		}
	}

	void OnDrawGizmosSelected () {
		Gizmos.color = new Color (1, 0, 0, 0.5f);
		Gizmos.DrawWireCube (center, size);

//		Gizmos.color = Color.blue;
//		Gizmos.DrawWireCube (center, detectRange);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			spawnWait = spawnFirstWait;
			StartCoroutine (SpawnerWait ());
		}
	}


}
