using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralSoldier : BaseSoldier {

    public AOEAttack m_aoeAttack;

    public GeneralSoldier()
    {
        m_profession = Profession.GeneralSoldier;
    }
	
    public override void UseSkill()
    {
        base.UseSkill();

        if (m_aoeAttack != null)
        {
            m_aoeAttack.Attack(m_nowDirection);
        }
    }

    public override void Init(Direction dir)
    {
        base.Init(dir);

        SetDirection(dir);
    }

    public override void SetDirection(Direction dir)
    {
        base.SetDirection(dir);
        if (m_aoeAttack != null)
        {
            m_aoeAttack.SetDirection(m_nowDirection);
        }
    }



}
