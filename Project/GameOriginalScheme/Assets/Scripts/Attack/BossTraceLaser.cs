using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTraceLaser : MonoBehaviour {

    public float speed;
    private Vector2 target;
    private Transform player;
    public float damage;
    public float duringTime = 10;

    void Start()
    {
        player = PlayerController.GetPlayerObject().transform;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        duringTime -= Time.deltaTime;
        if (duringTime < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
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
