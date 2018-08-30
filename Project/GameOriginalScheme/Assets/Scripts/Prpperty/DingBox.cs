using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DingBox : MonoBehaviour 
{
    public Profession m_Profession;

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
                Destroy(this.gameObject);
            }
        }
    }
	
}
