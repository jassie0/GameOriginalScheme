using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldTrigger : MonoBehaviour
{
    public float hitForce = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject player = PlayerController.GetPlayerObject();
        if (player == null)
        {
            return;
        }

        if (other.tag == "Enemy")
        {
            Vector2 pushDir = other.transform.position - player.transform.position;
            pushDir = -pushDir.normalized;

            other.GetComponent<Rigidbody2D>().AddForce(-pushDir * hitForce * 1);
        }
    }
}
