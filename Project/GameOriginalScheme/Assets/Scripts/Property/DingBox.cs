using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DingBox : MonoBehaviour 
{
    public Profession m_Profession;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject kingObj = PlayerControl.GetPlayer();
            if (kingObj == null)
            {
                Debug.LogError("Can not find King");
                return;
            }

            PlayerControl kingController = kingObj.GetComponent<PlayerControl>();
            bool isOn = kingController.GetSoldier(m_Profession);
            if(isOn)
            {
                CGame.Instance.SoundSystem.PlaySound("dingBox");
                CGame.Instance.SoundSystem.PlaySound("getSoilder");
                Destroy(this.gameObject);
            }
        }
    }
	
}
