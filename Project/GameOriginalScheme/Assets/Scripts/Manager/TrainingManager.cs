using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingManager : MonoSingleton<TrainingManager>
{
    public void SendTrainingMassage(string massage)
    {
        UIControl.Instance().TrainingMassage(massage);
        UIControl.Instance().OpenWindow(UI_TYPE.Training);
    }

}
