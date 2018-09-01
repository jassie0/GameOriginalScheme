using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldTrigger : MonoBehaviour
{
    public float hitForce = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Vector2 pushDir = other.transform.position - transform.position;
            pushDir = -pushDir.normalized;
            other.GetComponent<Rigidbody2D>().AddForce(-pushDir * hitForce * 1);
        }
    }
}
