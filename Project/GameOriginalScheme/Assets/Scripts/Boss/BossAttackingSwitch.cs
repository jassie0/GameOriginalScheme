using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackingSwitch : MonoBehaviour
{
    public BossController m_bossController;
    public Animator m_animator;

    public void BeginAttack()
    {
        m_bossController.IsAttacking = true;
    }

    public void EndAttack()
    {
        m_bossController.IsAttacking = false;
        //m_bossController.ResetTimeTick();
    }

    public void LaserAttack()
    {
        m_bossController.LaserAttack();
    }

    public void TraceLaserAttack()
    {
        m_bossController.TraceLaserAttack();
    }
}
