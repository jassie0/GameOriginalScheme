using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DingBox : MonoBehaviour 
{
    public Profession m_Profession;
    public bool m_destoryAfterEat = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("King"))
        {

            PlayerController kingController = PlayerController.GetPlayerObject().GetComponent<PlayerController>();
            bool isOn = kingController.GetSoldier(m_Profession);
            if(isOn)
            {
                SoundManager.Instance().PlaySound("dingBox");
                SoundManager.Instance().PlaySound("getSoilder");
                if (m_destoryAfterEat)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
	
}
