using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Profession
{
    SwordSoldier,
    ArcherSoldier,
    GeneralSoldier
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

    //public void RotateAroundPivot(Direction direction, Transform nubing)
    //{
    //    if (direction == Direction.Up)
    //    {

    //    }
    //    else if (direction == Direction.Right)
    //    {
    //        nubing.Rotate(0, 0, -90);
    //    }
    //    else if (direction == Direction.Down)
    //    {
    //        nubing.Rotate(0, 0, -180);
    //    }
    //    else if (direction == Direction.Left)
    //    {
    //        nubing.Rotate(0, 0, -270);
    //    }

    //}

    //public Direction GetCurrectDirection(Direction defaultDir, Direction playerDir)
    //{
    //    int dirNum = ((int)defaultDir + (int)playerDir) % 4;

    //    return (Direction)dirNum;
    //}


}
