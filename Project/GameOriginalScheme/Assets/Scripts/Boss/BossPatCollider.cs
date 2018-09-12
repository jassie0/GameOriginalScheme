using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatCollider : MonoBehaviour {

    public BossController m_bossController;
    public Transform m_patPoint;
    public float hitForce = 8;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CharacterHealth health = collision.GetComponent<CharacterHealth>();
            health.TakeDamage(m_bossController.m_patDamage);
        }
        else if (collision.tag == "King")
        {
            CharacterHealth health = collision.GetComponent<CharacterHealth>();
            health.TakeDamage(m_bossController.m_patDamage);

            Vector2 pushDir = collision.transform.position - m_patPoint.position;
            pushDir =- pushDir.normalized;
            collision.GetComponent<Rigidbody2D>().AddForce(-pushDir * hitForce * 100000000);
        }
    }
}
