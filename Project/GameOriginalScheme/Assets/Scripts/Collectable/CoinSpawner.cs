using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {
	public Vector2 spawnSize;
	public GameObject coinPrefab;
	public int maxCoins;
	public int spawnTime;
	public bool stop;
	int coinNum = 0;
	// Use this for initialization
	void Start () {
		spawnTime = Random.Range (0, maxCoins);
		StartCoroutine (SpawnCoins ());
	}
	
	// Update is called once per frame
	void Update () {
		if (coinNum >= spawnTime) {
			stop = true;
		} 
	}

	IEnumerator SpawnCoins () {
		while (!stop) {
			Vector2 spawnPosition = transform.position + new Vector3 (Random.Range (-spawnSize.x / 2, spawnSize.x / 2), Random.Range (-spawnSize.y / 2, spawnSize.y / 2), transform.position.z);
			Instantiate (coinPrefab, spawnPosition, Quaternion.identity);
			yield return null;
			coinNum = coinNum + 1;
		}

	}
		
	void OnDrawGizmosSelected () {
		Gizmos.color = new Color (1, 0, 0, 0.5f);
		Gizmos.DrawWireCube (transform.position, spawnSize);
	}
}
