using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSoldierAttack : MonoBehaviour {

    public MeleeAttack m_MeleeAttack;

    public void SwordAttack()
    {
        if (m_MeleeAttack != null)
        {
            m_MeleeAttack.TakeDamage();
        }

        //Debug.Log("SwordAttack");
    }
}
