using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistoryThisAfterAWhile : MonoBehaviour {

    public float m_Time = 10f;      // Use this for initialization     void Start () 
    {              }        // Update is called once per frame     void Update ()      {         if(m_Time > 0)         {             m_Time -= Time.deltaTime;         }         else         {             Destroy(this.gameObject);         }     } 
}
