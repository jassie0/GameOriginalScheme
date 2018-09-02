using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingSession : UIWindow {

    //public GameObject m_tipBG;
    //public GameObject m_moveTip;
    //public GameObject m_rotateTip;
    //public GameObject m_attackTip;

    //private bool isMoveTipOn = false;
    //private bool isRotateTipOn = false;
    //private bool isAttackTipOn = false;

    public Text m_trainingMassage;

    public void OnEnable()
    {
        GameController.Instance().PauseGame(true);
    }

    public void OnDisable()
    {
        GameController.Instance().PauseGame(false);
    }

    public override void SetWindow(string data)
    {
        m_trainingMassage.text = data;
        //base.SetWindow(data);
        //if(data == "MovingTip")
        //{
        //    SetMoveTip();
        //}
        //else if(data == "RotateTip")
        //{
        //    SetRotateTip();
        //}
        //else if(data == "AttackTip")
        //{
        //    SetAttackTip();
        //}
    }

    //public void SetMoveTip()
    //{
    //    GameController.instance.PauseGame(true);
    //    m_tipBG.SetActive(true);
    //    m_moveTip.SetActive(true);
    //    m_rotateTip.SetActive(false);
    //    m_attackTip.SetActive(false);
    //    isMoveTipOn = true;

    //    UIControl.Instance().OpenSingleWindow(UI_TYPE.MovingTips);
    //}

    //public void SetRotateTip()
    //{
    //    GameController.instance.PauseGame(true);
    //    m_tipBG.SetActive(true);
    //    m_moveTip.SetActive(false);
    //    m_rotateTip.SetActive(true);
    //    m_attackTip.SetActive(false);
    //    isRotateTipOn = true;
    //}

    //public void SetAttackTip()
    //{
    //    GameController.instance.PauseGame(true);
    //    m_tipBG.SetActive(true);
    //    m_moveTip.SetActive(false);
    //    m_rotateTip.SetActive(false);
    //    m_attackTip.SetActive(true);
    //    isAttackTipOn = true;
    //}

    public void CloseTip()
    {
        //if(isMoveTipOn == true)
        //{
        //    UIWindow movingWindow = UIControl.Instance().GetWindow(UI_TYPE.MovingTips);
        //    movingWindow.Open();
        //    movingWindow.SetWindow("Down");
        //}

        //if(isRotateTipOn == true)
        //{
        //    UIWindow movingWindow = UIControl.Instance().GetWindow(UI_TYPE.MovingTips);
        //    movingWindow.Open();
        //    movingWindow.SetWindow("Right");
        //}

        //isMoveTipOn = false;
        //isRotateTipOn = false;
        //isAttackTipOn = false;
        //GameController.instance.PauseGame(false);
        //m_tipBG.SetActive(false);
        //Close();
    }


    private void Update()
    {
        if (Input.anyKeyDown)
        {
            Close();
        }

        //if(isMoveTipOn)
        //{
        //    if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)||
        //        Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        //    {
        //        CloseTip();
        //    }
        //}
        //else if(isRotateTipOn)
        //{
        //    if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
        //    {
        //        CloseTip();
        //    }
        //}
        //else if(isAttackTipOn)
        //{
        //    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
        //        Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        //    {
        //        CloseTip();
        //    }
        //}

    }
}
