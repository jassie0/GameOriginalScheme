using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject kingObj = PlayerController.GetPlayerObject();
            if (kingObj == null)
            {
                Debug.LogError("Can not find King");
                return;
            }

            UIControl.instance.SetGameOver(true);

            //PlayerController kingController = kingObj.GetComponent<PlayerController>();
            //bool isOn = kingController.GetSoldier(m_Profession);
            //if (isOn)
            //{
            //    SoundManager.instance.PlaySound("dingBox");
            //    SoundManager.instance.PlaySound("getSoilder");
            //    Destroy(this.gameObject);
            //}
        }
    }
}
