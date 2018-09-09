using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossSkill
{
    LeftArmPat,
    LeftArmSweep,
    RightArmPat,
    RightArmSweep,
    BossLaser,
    BossTraceLaser,
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
    public Animator m_BossAnimator;

    public float m_moveSpeed = 1f;
    public float m_trackTime = 3f;
    public float m_trackDistance = 0.5f;
    private float m_trackTimeTick = 0;

    public float m_attackDistance = 10.5f;

    private Rigidbody2D m_boss;
    private CharacterHealth m_characterHealth;
    private PlayerController m_playerController;
    //private BossState m_bossState = BossState.One;
    //private BossSkill m_bossSkill;
    private const float m_bossMoveDistance = 6.5f;
    //private bool Moving = false;

    private bool isAttacking = false;
    public bool IsAttacking { set { isAttacking = value; } get { return isAttacking; } }
    private float BossYPosition;
   

    private void Awake()
    {
        m_boss = GetComponent<Rigidbody2D>();
        m_characterHealth = GetComponent<CharacterHealth>();
        m_playerController = PlayerController.Instance().GetComponent<PlayerController>();
        BossYPosition = transform.position.y;
        m_trackTimeTick = m_trackTime;
    }

    private void Update()
    {
        //if (m_BossAnimator == null)
        //{
        //    return;
        //}

        if (m_playerController == null)
        {
            return;
        }

        if (m_trackTimeTick > 0)
        {
            m_trackTimeTick -= Time.deltaTime;
            MoveTo();
            return;
        }

        Attack();
    }

    public void MoveTo()
    {
        Vector2 dir = new Vector2((m_playerController.transform.position - transform.position).x, 0);
        Vector2 targetPos = (Vector2)transform.position + dir * m_moveSpeed * Time.deltaTime;
        m_boss.MovePosition(targetPos);
    }

    public void Attack()
    {
        float tempDistance = Mathf.Abs(m_playerController.transform.position.x - transform.position.x);
        if (tempDistance < m_trackDistance)
        {
            MeleeAttack();
        }
        else
        {
            LongDistanceAttack();
        }
    }

    public void MeleeAttack()
    {
        int bossSkill = Random.Range((int)BossSkill.LeftArmPat, (int)BossSkill.RightArmSweep);

        m_BossAnimator.SetBool("Moving", false);
        m_BossAnimator.SetInteger("SkillID", bossSkill);
        m_BossAnimator.SetTrigger("Attack");
        //m_trackTimeTick = m_trackTime;
    }

    public void LongDistanceAttack()
    {
        int bossSkill = Random.Range((int)BossSkill.BossLaser, (int)BossSkill.BossTraceLaser);

        m_BossAnimator.SetBool("Moving", false);
        m_BossAnimator.SetInteger("SkillID", bossSkill);
        m_BossAnimator.SetTrigger("Attack");
        //m_trackTimeTick = m_trackTime;
    }

    public void ResetTimeTick()
    {
        m_trackTimeTick = m_trackTime;
    }

    /*
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

    public void Attack()
    {
        
        if (m_bossState == BossState.One)
        {
            int bossSkill = Random.Range((int)BossSkill.LeftArmPat, (int)BossSkill.RightArmSweep);

            m_BossAnimator.SetInteger("SkillID", bossSkill);
            m_BossAnimator.SetTrigger("Attack");

        }
        else if (m_bossState == BossState.Two)
        {
            int bossSkill = Random.Range((int)BossSkill.LeftArmPat, (int)BossSkill.BossTraceLaser);

            m_BossAnimator.SetInteger("SkillID", bossSkill);
            m_BossAnimator.SetTrigger("Attack");
        }
        else
        {
            int bossSkill = Random.Range((int)BossSkill.LeftArmPat, (int)BossSkill.BossTraceLaser);

            m_BossAnimator.SetInteger("SkillID", bossSkill);
            m_BossAnimator.SetTrigger("Attack");
        }
        
    }*/
}
