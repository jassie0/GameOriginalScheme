using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSoldier : BaseSoldier
{
    public MeleeAttack m_attack;

    public SwordSoldier()
    {
        m_profession = Profession.SwordSoldier;
    }

    public override void UseSkill() 
    {
        base.UseSkill();

        if (m_attack != null)
        {
            m_attack.Attack(m_nowDirection);
        }
    }
}
