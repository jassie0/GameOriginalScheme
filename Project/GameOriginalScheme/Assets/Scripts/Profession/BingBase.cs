using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Profession
{
    JianBing,
    NuBing,
    JiangJunBing,
}

public class BingBase : MonoBehaviour {

    protected Profession m_profession;
    public Profession Profession{ get { return m_profession; }}

    public GameObject m_skillPrefab;
    public Direction m_defaultDirection;
    //public Animator m_bingAni;


    public virtual void UseSkill(Direction dir)
    {
        if(m_skillPrefab == null)
        {
            Debug.LogError("技能未初始化:" + m_profession.ToString());
            return;
        }

        //if(m_bingAni == null)
        //{
        //    Debug.LogError("动画未指定:" + gameObject.name.ToString());
        //}

        //Direction curDirection = GetCurrectDirection(m_defaultDirection, dir);


        //if (curDirection == Direction.Up)
        //{
        //    m_bingAni.SetFloat("AttackDirection", 0.66f);
        //}
        //else if (curDirection == Direction.Right)
        //{
        //    m_bingAni.SetFloat("AttackDirection", 1f);
        //}
        //else if (curDirection == Direction.Down)
        //{
        //    m_bingAni.SetFloat("AttackDirection", 0.0f);
        //}
        //else if (curDirection == Direction.Left)
        //{
        //    m_bingAni.SetFloat("AttackDirection", 0.33f);
        //}

        //m_bingAni.SetTrigger("Attacking");

    }


    public virtual void Init(Direction dir)
    {
        m_defaultDirection = dir;
    }

    public virtual void Release(){}

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

    public Direction GetCurrectDirection(Direction defaultDir, Direction playerDir)
    {
        int dirNum = ((int)defaultDir + (int)playerDir) % 4;

        return (Direction)dirNum;
    }


}
