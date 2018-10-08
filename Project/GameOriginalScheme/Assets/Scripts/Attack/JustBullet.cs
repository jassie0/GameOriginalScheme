using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustBullet : MonoBehaviour {
    public float damage;
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
        else if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
