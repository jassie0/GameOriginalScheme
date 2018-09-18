using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralSoldierAttack : MonoBehaviour {

    public AOEAttack m_AOEAttack;

    public void TakeAOE()
    {
        if (m_AOEAttack != null)
        {
            m_AOEAttack.TakeAttackRange();
            SoundManager.Instance().PlaySound("generalAttack");
        }
    }
}
