using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : ISceneState {

    public BattleState(SceneStateController Controller) : base(Controller)
    {
        this.StateName = "BattleState";
    }

    // 開始
    public override void StateBegin()
    {
        CGame.Instance.Create();
    }

    // 結束
    public override void StateEnd()
    {
        CGame.Instance.Release();
    }

    // 更新
    public override void StateUpdate()
    {
        // 遊戲邏輯
        CGame.Instance.Create();
        // Render由Unity負責

        // 遊戲是否結束
        //if (CGame.Instance.ThisGameIsOver())
        //    m_Controller.SetState(new MainMenuState(m_Controller), "MainMenuScene");
    }
}
