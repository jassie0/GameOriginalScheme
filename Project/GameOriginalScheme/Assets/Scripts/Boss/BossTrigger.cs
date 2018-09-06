using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public BossController m_bossController;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (m_bossController != null)
            {
                m_bossController.Attack();
            }
        }
    }

}
