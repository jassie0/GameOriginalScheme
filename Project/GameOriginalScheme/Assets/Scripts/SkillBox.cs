using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Skill
{
    Arrow,
    Melee,
    None
}

public enum EnimyType
{
    JiGuangJianBing,
    JiGuangQiangBing,
    JingYingBing,
    CiBaoBing
}

public class SkillBox : MonoBehaviour
{
    public BingBase m_bing;
    public bool m_isOn = false;
    public Direction m_defaultDirection;

    public GameObject m_jianBing;
    public GameObject m_nuBing;
    public GameObject m_jiangJunBing;


    public virtual void UseSkill(Direction direction)
    {
        if (m_isOn && m_bing != null)
        {
            m_bing.UseSkill(direction);
        }

    }

    public virtual void Init(Profession pro, Direction defaultDir)
    {
        m_isOn = true;

        m_defaultDirection = defaultDir;

        if (m_jianBing == null || m_nuBing == null || m_jiangJunBing == null)
        {
            Debug.LogError("兵种未配置");
        }

        if (pro == Profession.JianBing)
        {
            CreateBing(m_jianBing);
        }
        else if (pro == Profession.NuBing)
        {
            CreateBing(m_nuBing);
        }
        else if (pro == Profession.JiangJunBing)
        {
            CreateBing(m_jiangJunBing);
        }
    }

    private void CreateBing(GameObject bingObj)
    {
        m_bing = Instantiate(bingObj, this.transform.position, Quaternion.identity, this.transform).GetComponent<BingBase>();
        if (m_bing != null)
        {
            m_bing.Init(m_defaultDirection);
        }
    }

    public virtual void Relese()
    {
        if (m_bing != null)
        {
            BingBase bing = m_bing.GetComponent<BingBase>();
            if (m_bing != null)
            {
                bing.Release();
            }

            Destroy(m_bing);
            m_bing = null;
        }

        m_isOn = false;
    }
}
