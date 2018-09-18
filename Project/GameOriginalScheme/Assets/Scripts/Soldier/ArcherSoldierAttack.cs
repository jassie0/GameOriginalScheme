using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSoldierAttack : MonoBehaviour {

    public ArcherSoldier m_archerSoldier;

    public void ArcherSolierAttack()
    {
        if (m_archerSoldier != null)
        {
            m_archerSoldier.SendArrow();
            SoundManager.Instance().PlaySound("archorAttack");
        }

    }
    
	void DistoryThisAfterDeath()
	{
		Destroy(gameObject);
	}    
}
