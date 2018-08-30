using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Profession
{
    SwordSoldier,
    ArcherSoldier,
    GeneralSoldier,
    ShieldSoldier
}

public class BaseSoldier : MonoBehaviour {

    protected Profession m_profession;
    public Profession Profession{ get { return m_profession; }}

    protected Direction m_nowDirection;

    public virtual void UseSkill()
    {

    }

    public virtual void Init(Direction dir)
    {
        m_nowDirection = dir;
    }

    public virtual void Release(){}

    public virtual void SetDirection(Direction dir)
    {
        m_nowDirection = dir;
    }
}
