using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSoldier : BaseSoldier {

    public GameObject m_arrowPrefab;
    public Animator m_soldierAnimator;
    public AudioSource m_attackSource;
    Transform m_arrow;
    Direction m_dir;

    public ArcherSoldier()
    {
        m_profession = Profession.ArcherSoldier;
    }

    public override void UseSkill()
    {
        base.UseSkill();

        if(m_arrow != null)
        {
            return;
        }

        m_arrow = Instantiate(m_arrowPrefab, this.transform.position, this.transform.rotation).transform;
        RotateAroundPivot(m_nowDirection, m_arrow);

//        if (m_attackSource != null)
//        {
//            m_attackSource.Play();
//        }
		SoundManager.PlaySound("archorAttack");

        if (m_soldierAnimator)
        {
            PlayAnimation(m_nowDirection);
        }
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
