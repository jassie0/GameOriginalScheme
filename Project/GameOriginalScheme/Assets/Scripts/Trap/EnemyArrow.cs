using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour {

	public float speed = 5;
	public float damage;
	public Rigidbody2D m_rigidbody;

	// Use this for initialization
	void Start () {
		m_rigidbody.velocity = this.transform.up * speed;
		SoundManager.Instance().PlaySound("arrowShoot");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player" || other.tag == "King")
		{
			other.GetComponent<CharacterHealth>().TakeDamage(damage);
			Destroy(gameObject);
		}
		else if (other.tag == "Shield")
		{
			Destroy(gameObject);
		}
	}
}
