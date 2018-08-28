using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTipAttack : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("King"))
        {
            UIWindow movingWindow = UIControl.instance.GetWindow(UI_TYPE.MovingTips);
            movingWindow.Close();
                
            UIWindow trainingWindow = UIControl.instance.GetWindow(UI_TYPE.TrainingSession);
            trainingWindow.Open();
            if(trainingWindow != null)
            {
                trainingWindow.SetWindow("AttackTip");
                Destroy(gameObject);
            }
        }
    }

}
