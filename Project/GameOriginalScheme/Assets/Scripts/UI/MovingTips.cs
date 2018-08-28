using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTips : UIWindow 
{
    public GameObject m_up;
    public GameObject m_down;
    public GameObject m_left;
    public GameObject m_right;

    public override void SetWindow(string data)
    {
        base.SetWindow(data);

        if(data == "Down")
        {
            m_up.SetActive(false);
            m_down.SetActive(true);
            m_left.SetActive(false);
            m_right.SetActive(false);
        }
        else if(data == "Right")
        {
            m_up.SetActive(false);
            m_down.SetActive(false);
            m_left.SetActive(false);
            m_right.SetActive(true);
        }
        else if(data == "Left")
        {
            m_up.SetActive(false);
            m_down.SetActive(false);
            m_left.SetActive(true);
            m_right.SetActive(false);
        }
        else if(data == "Up")
        {
            m_up.SetActive(true);
            m_down.SetActive(false);
            m_left.SetActive(false);
            m_right.SetActive(false);
        }
    }
}
