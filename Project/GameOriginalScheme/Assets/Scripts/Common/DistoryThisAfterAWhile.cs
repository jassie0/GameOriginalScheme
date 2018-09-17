using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistoryThisAfterAWhile : MonoBehaviour {

    public float m_Time = 10f;

    public void SetTime(float time)
    {
        m_Time = time;
    }

    void Update () 
    {
        if(m_Time > 0)
        {
            m_Time -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
