using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour {
	public float speed;
	private Vector2 target;
	private Transform player;
	public float damage;
    public float duringTime = 15;

    private Vector2 dir;

	void Start () {		
        player = PlayerController.GetPlayerObject().transform;
		target = new Vector2 (player.transform.position.x, player.transform.position.y);

        dir = (target - (Vector2)transform.position).normalized;
    }
	
	void Update () {

        
        Vector2 targetPos = (Vector2)transform.position + dir * speed * Time.deltaTime;
        transform.position = targetPos;

        //transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);
        //if (transform.position.x == target.x && transform.position.y == target.y)
        //{
        //    Destroy(gameObject);
        //}

        duringTime -= Time.deltaTime;
        if (duringTime < 0)
        {
            Destroy(gameObject);
        }
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
