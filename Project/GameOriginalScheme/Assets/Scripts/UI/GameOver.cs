using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : UIWindow 
{
    public GameObject m_Win;
    public GameObject m_Lose;

    public override void SetWindow(string data)
    {
        base.SetWindow();
        if(data == "Win")
        {
            m_Win.SetActive(true);
            m_Lose.SetActive(false);
        }
        else if(data == "Lose")
        {
            m_Win.SetActive(false);
            m_Lose.SetActive(true);
        }
    }

    public void OnClick_Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Close();
    }

    public void OnClick_BackTo()
    {
        UIControl.instance.OpenWindow(UI_TYPE.SelectLevel);
        GameController.instance.SetInFightScene(false);
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
