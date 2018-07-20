using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject MeleeEnemyPrefab;

	public Vector2 center;
	public Vector2 size;

	public GameObject[] enemies;
	//public Vector2 spawnValues;
	private float spawnWait;
	public float spawnFirstWait;
	public float spawnSecondWait;
	public int startWait;
	public bool stop;
	public int spawnTime = 0;

	int randomEnemy;


	// Use this for initialization
	void Start () {
		spawnWait = spawnFirstWait;
		StartCoroutine (SpawnerWait ());
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnTime >= 2) {
			stop = true;
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
	}
}
