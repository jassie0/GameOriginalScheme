using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldTrigger : MonoBehaviour
{
    Collider2D m_collider;

    public float hitForce = 1;

    void Awake()
    {
        m_collider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject player = PlayerController.GetPlayerObject();
        if (player == null)
        {
            return;
        }

        // if (other.tag == "Enemy")
        // {
        //     m_collider.isTrigger = false;

        //     //Vector2 pushDir = other.transform.position - player.transform.position;
        //     //pushDir = -pushDir.normalized;

        //     //other.GetComponent<Rigidbody2D>().AddForce(-pushDir * hitForce * 1);
        // }
        // else
        // {
        //     m_collider.isTrigger = true;

        // }
    }
}
