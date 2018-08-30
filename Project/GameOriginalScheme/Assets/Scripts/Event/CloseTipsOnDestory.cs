using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTipsOnDestory : MonoBehaviour {

    private void OnDisable()
    {
        UIControl.instance.CloseWindow(UI_TYPE.MovingTips);

        UIWindow training = UIControl.instance.GetWindow(UI_TYPE.TrainingSession);
        training.Open();
        if(training != null)
        {
            training.SetWindow("RotateTip");
        }
    }
}
