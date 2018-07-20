using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JianBing : BingBase {
    
    public MeleeAttack m_attack;

	void Start () 
    {
        m_profession = Profession.JianBing;
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public override void UseSkill(Direction dir) 
    {
        base.UseSkill(dir);

        if (m_attack != null)
        {
            Direction curDirection = GetCurrectDirection(m_defaultDirection, dir);

            m_attack.Attack(curDirection);

        }


        //RotateAroundPivot(dir, m_attack);
    }

    public override void Init(Direction dir) 
    {
        base.Init(dir);
        //m_attack = Instantiate(m_skillPrefab, this.transform.position, this.transform.rotation).GetComponent<MeleeAttack>();
    }


}
