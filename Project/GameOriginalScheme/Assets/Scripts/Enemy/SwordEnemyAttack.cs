using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemyAttack : MonoBehaviour {
    
    public EnemyMelee m_enemyMelee;

    public void EnemyMeleeAttack()
    {
        if (m_enemyMelee != null)
        {
            m_enemyMelee.EnemyMeleeDamage();
        }
    }

	void StopAttack () {
		m_enemyMelee.GetComponent<EnemyMelee> ().enemyAttack = false;
	}

}
