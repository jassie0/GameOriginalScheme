using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSoldier : BaseSoldier {

    public GameObject m_arrowPrefab;
    public Animator m_soldierAnimator;
    public AudioSource m_attackSource;
    public float m_cdTime = 1.5f;
    private float m_cdCount = 0;
    private Direction m_dir;
    public Direction Direction{ get { return m_dir; }}

    public ArcherSoldier()
    {
        m_profession = Profession.ArcherSoldier;
    }

    void Update()
    {
        if (m_cdCount > 0)
        {
            m_cdCount -= Time.deltaTime;
        }
    }

    public override void UseSkill()
    {
        base.UseSkill();

        if (m_cdCount > 0)
        {
            return;
        }

        m_cdCount = m_cdTime;

        SoundManager.Instance().PlaySound("archorAttack");

        if (m_soldierAnimator)
        {
            PlayAnimation(m_nowDirection);
        }
    }

    public void SendArrow()
    {
        Transform arrow = Instantiate(m_arrowPrefab, this.transform.position, this.transform.rotation).transform;
        RotateAroundPivot(m_nowDirection, arrow);
    }


    public override void Init(Direction dir)
    {
        base.Init(dir);
        m_dir = dir;
    }

    public void PlayAnimation(Direction curDirection)
    {
        if (curDirection == Direction.Up)
        {
            m_soldierAnimator.SetFloat("AttackDirection", 0.66f);
        }
        else if (curDirection == Direction.Right)
        {
            m_soldierAnimator.SetFloat("AttackDirection", 1f);
        }
        else if (curDirection == Direction.Down)
        {
            m_soldierAnimator.SetFloat("AttackDirection", 0.0f);
        }
        else if (curDirection == Direction.Left)
        {
            m_soldierAnimator.SetFloat("AttackDirection", 0.33f);
        }

        m_soldierAnimator.SetTrigger("Attacking");
    }


    public void RotateAroundPivot(Direction direction, Transform nubing)
    {
        if (direction == Direction.Up)
        {
            nubing.Rotate(0, 0, 0);
        }
        else if (direction == Direction.Right)
        {
            nubing.Rotate(0, 0, -90);
        }
        else if (direction == Direction.Down)
        {
            nubing.Rotate(0, 0, -180);
        }
        else if (direction == Direction.Left)
        {
            nubing.Rotate(0, 0, -270);
        }
    }

}
