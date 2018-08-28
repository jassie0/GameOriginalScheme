using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessScore : UIWindow {

    public int m_score = 100;
    public Text m_scoreText;

    private int m_totalScore = 0;

    public override void SetWindow()
    {
        base.SetWindow();
        AddScore();
    }

    public void AddScore()
    {
        m_scoreText.text = "分数：" + (m_totalScore += m_score).ToString();
    }

    public void ResetScore()
    {
        m_totalScore = 0;
    }


}
