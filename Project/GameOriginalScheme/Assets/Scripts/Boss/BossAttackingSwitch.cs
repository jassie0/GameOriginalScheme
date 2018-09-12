using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackingSwitch : MonoBehaviour
{
    public BossController m_bossController;
    public Animator m_animator;
    public BossPatCollider m_LeftPatCollider;
    public BossPatCollider m_RightPatCollider;
    public BossPatCollider[] m_LeftSweep;
    public BossPatCollider[] m_RightSweep;

    public void BeginAttack()
    {
        m_bossController.IsAttacking = true;
    }

    public void EndAttack()
    {
        m_bossController.IsAttacking = false;
        //m_bossController.ResetTimeTick();
        m_LeftSweep[m_LeftSweep.Length - 1].gameObject.SetActive(false);
        m_RightSweep[m_RightSweep.Length - 1].gameObject.SetActive(false);
    }

    public void LaserAttack()
    {
        m_bossController.LaserAttack();
    }

    public void TraceLaserAttack()
    {
        m_bossController.TraceLaserAttack();
    }

    public void LeftPatAttack()
    {
        StartCoroutine(PatAttack(m_LeftPatCollider));
    }

    public void RightPatAttack()
    {
        StartCoroutine(PatAttack(m_RightPatCollider));
    }

    IEnumerator PatAttack(BossPatCollider collider)
    {
        collider.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        collider.gameObject.SetActive(false);
    }

    public void LeftSweep(int sweep)
    {
        for (int i = 0; i < m_LeftSweep.Length; i++)
        {
            if (i == sweep)
            {
                m_LeftSweep[i].gameObject.SetActive(true);
            }
            else
            {
                m_LeftSweep[i].gameObject.SetActive(false);
            }
        }
    }

    public void RightSweep(int sweep)
    {
        for (int i = 0; i < m_RightSweep.Length; i++)
        {
            if (i == sweep)
            {
                m_RightSweep[i].gameObject.SetActive(true);
            }
            else
            {
                m_RightSweep[i].gameObject.SetActive(false);
            }
        }
    }
}
