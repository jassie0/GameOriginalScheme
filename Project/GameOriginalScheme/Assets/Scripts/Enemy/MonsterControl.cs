using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterControl : MonoBehaviour {

	public float _monsterSpeed = 0.1f;

	private Transform _player;
	private Rigidbody2D _monster;

	public int health;

	public float checkRadius;
	public LayerMask checkLayers;
	public RandomMonsterSpawn _monsterManager;

	void Awake()
	{
		_monster = this.GetComponent<Rigidbody2D> ();
	}

	public void InitMonster(GameObject player)
	{
		_player = player.transform;
	}
		
	void Update()
	{
		if (_monster != null && _player != null) 
		{			
			Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position, checkRadius, checkLayers);
			Array.Sort (colliders, new DistCompare (transform));

			foreach (Collider2D player in colliders){
				Vector2 dir = (Vector2)player.transform.position - (Vector2)_monster.transform.position;
				Vector2 nextPosition = (Vector2)_monster.position + dir * _monsterSpeed * Time.deltaTime;
				_monster.MovePosition (nextPosition);
			}
		}

		if (health <= 0) {
			Destroy(gameObject);
		}	
			
	}

	public void TakeDamage (int damage) {
		health -= damage;
	}



	void OnTirggerEnter2D(Collider2D other)
	{
		if (other.tag == "Arrow") 
		{
			//Destroy (this.gameObject);
		}

	}

	private void OnDrawGizmos(){
		Gizmos.DrawWireSphere (transform.position, checkRadius);
	}


}
