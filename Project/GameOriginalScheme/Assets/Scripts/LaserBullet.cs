﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour {
	public float speed;
	private Vector2 target;
	private Transform player;
	public float damage;
	// Use this for initialization
	void Start () {		
		player = GameObject.Find ("King").transform;
		target = new Vector2 (player.transform.position.x, player.transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);
		if (transform.position.x == target.x && transform.position.y == target.y) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			other.GetComponent<CharacterHealth> ().TakeDamage(damage);
			Destroy (gameObject);
		}
	}
}
