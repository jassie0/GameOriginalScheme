using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBox : MonoBehaviour
{
    private BaseSoldier m_soldier;
    public bool m_isOn = false;
    public GameObject m_swordSoldier;
    public GameObject m_archerSoldier;
    public GameObject m_generalSoldier;

    private Direction m_nowDirection;
    public Direction NowDirection   //士兵目前方位
    {
        get { return m_nowDirection; }
    }

    public void SetDirection(Direction direction)
    {
        m_nowDirection = direction;
        if (m_soldier != null)
        {
            m_soldier.SetDirection(direction);
        }
    }

    public virtual void UseSkill()
    {
        if (m_isOn && m_soldier != null)
        {
            m_soldier.UseSkill();
        }
    }

    public virtual void Init(Profession pro)
    {
        m_isOn = true;

        if (m_swordSoldier == null || m_archerSoldier == null || m_generalSoldier == null)
        {
            Debug.LogError("兵种未配置");
        }

        if (pro == Profession.SwordSoldier)
        {
            CreateSoldier(m_swordSoldier);
        }
        else if (pro == Profession.ArcherSoldier)
        {
            CreateSoldier(m_archerSoldier);
        }
        else if (pro == Profession.GeneralSoldier)
        {
            CreateSoldier(m_generalSoldier);
        }
    }

    public virtual void Relese()
    {
        if (m_soldier != null)
        {
            BaseSoldier bing = m_soldier.GetComponent<BaseSoldier>();
            if (m_soldier != null)
            {
                bing.Release();
            }

            Destroy(m_soldier);
            m_soldier = null;
        }

        m_isOn = false;
    }

    private void CreateSoldier(GameObject bingObj)
    {
        m_soldier = Instantiate(bingObj, this.transform.position, Quaternion.identity, this.transform).GetComponent<BaseSoldier>();
        if (m_soldier != null)
        {
            m_soldier.Init(m_nowDirection);
        }
    }

}
