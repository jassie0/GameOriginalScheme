using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossSkill
{
    NormalAttack,
    SweepAttack,
    ThreeAttack,
    EyeLaser,
    BallLaser,
    Max
}

public enum BossState
{
    One,
    Two,
    Three
}

public class BossController : MonoBehaviour
{
    public float m_moveSpeed = 2f;
    public float m_trackTime = 5f;
    public Animator m_BossAnimator;

    private CharacterHealth m_characterHealth;
    private PlayerController m_playerController;
    private BossState m_bossState = BossState.One;
    private BossSkill m_bossSkill;
    private const float m_bossMoveDistance = 6.5f;
    private bool needToMove = false;
    private bool isAttacking = false;
    public bool IsAttacking { set { isAttacking = value; } get { return isAttacking; } }
   

    private void Awake()
    {
        m_characterHealth.GetComponent<CharacterController>();
        m_playerController = PlayerController.Instance().GetComponent<PlayerController>();
    }

    public void BossComeOn()
    {
        StartCoroutine(BossAttack());

    }

    private void Update()
    {
        if (m_BossAnimator == null)
        {
            return;
        }

        if (m_playerController == null)
        {
            return;
        }
    }

    public void Attack()
    {
        if (m_bossState == BossState.One)
        {

        }
        else if (m_bossState == BossState.Two)
        {

        }
        else
        {

        }
        
    }

    IEnumerator BossAttack()
    {
        while (m_characterHealth != null)
        {
            if (m_characterHealth.IsAlive)
            {
                break;
            }

            if (m_characterHealth.HealthPrecent > 0.75)
            {
                if (m_bossState != BossState.One)
                {
                    m_bossState = BossState.One;
                }
            }
            else if (m_characterHealth.HealthPrecent > 0.33)
            {
                if (m_bossState != BossState.Two)
                {
                    m_bossState = BossState.Two;
                }
            }
            else
            {
                if(m_bossState != BossState.Three)
                {
                    m_bossState = BossState.Three;
                }
            }

            yield return null;
        }

    }
}
