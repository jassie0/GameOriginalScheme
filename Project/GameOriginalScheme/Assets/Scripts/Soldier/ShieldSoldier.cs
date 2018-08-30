using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSoldier : BaseSoldier
{
    public ShieldAttack m_attack;

    public ShieldSoldier()
    {
        m_profession = Profession.ShieldSoldier;
    }

    public override void UseSkill()
    {
        base.UseSkill();

        if (m_attack != null)
        {
            m_attack.Attack(m_nowDirection);
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
        if (m_attack != null)
        {
            m_attack.SetDirection(m_nowDirection);
        }
    }

}
