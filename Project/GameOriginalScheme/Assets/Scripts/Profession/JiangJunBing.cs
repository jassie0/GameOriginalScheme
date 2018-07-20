using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JiangJunBing : BingBase {


    public AOEAttack m_aoeAttack;
    Direction m_dir;

	// Use this for initialization
	void Start () {
        m_profession = Profession.JiangJunBing;

	}
	
    public override void UseSkill(Direction dir)
    {
        base.UseSkill(dir);

        if (m_aoeAttack != null)
        {
            Direction curDirection = GetCurrectDirection(m_defaultDirection, dir);
            m_aoeAttack.Attack(curDirection);

        }


        //RotateAroundPivot(GetMyDirection(m_dir, dir), m_aoeAttack.transform);
    }

    public override void Init(Direction dir)
    {
        base.Init(dir);
        m_dir = dir;

        RotateAroundPivot(GetMyDirection(m_dir, dir), m_aoeAttack.transform);
    }

    private Direction GetMyDirection(Direction defaultDir, Direction playerDir)
    {
        int dirNum = ((int)defaultDir + (int)playerDir + 2) % 4;

        return (Direction)dirNum;
    }
}
