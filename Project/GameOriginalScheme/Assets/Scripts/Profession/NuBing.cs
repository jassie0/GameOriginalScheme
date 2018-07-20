using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuBing : BingBase {

    public Animator m_bingAni;
    public AudioSource m_attackSource;
    Transform m_arrow;
    Direction m_dir;

	// Use this for initialization
	void Start () {
        m_profession = Profession.NuBing;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void UseSkill(Direction dir)
    {
        base.UseSkill(dir);

        if(m_arrow != null)
        {
            return;
        }

        m_arrow = Instantiate(m_skillPrefab, this.transform.position, this.transform.rotation).transform;
        if (m_attackSource != null)
        {
            m_attackSource.Play();
        }

        if (m_bingAni)
        {
            PlayAnimation(dir);
        }

        RotateAroundPivot(GetCurrectDirection(m_dir, dir), m_arrow);

    }

    public override void Init(Direction dir)
    {
        base.Init(dir);
        m_dir = dir;
    }

    public void PlayAnimation(Direction curDirection)
    {
        //Direction curDirection = GetCurrectDirection(m_defaultDirection, dir);


        if (curDirection == Direction.Up)
        {
            m_bingAni.SetFloat("AttackDirection", 0.66f);
        }
        else if (curDirection == Direction.Right)
        {
            m_bingAni.SetFloat("AttackDirection", 1f);
        }
        else if (curDirection == Direction.Down)
        {
            m_bingAni.SetFloat("AttackDirection", 0.0f);
        }
        else if (curDirection == Direction.Left)
        {
            m_bingAni.SetFloat("AttackDirection", 0.33f);
        }

        m_bingAni.SetTrigger("Attacking");

    }
}
