using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingTrigger : MonoBehaviour
{
    public string m_trainingMassage;

    public void SendMassage()
    {
        TrainingManager.Instance().SendTrainingMassage(m_trainingMassage);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "King")
        {
            SendMassage();
            Destroy(gameObject);
        }

        
    }
}
