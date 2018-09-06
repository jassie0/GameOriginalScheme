using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public float shakeTime = 2f;
    private Camera mainCamera;
    private Vector3 mCurPos;
    private float deFactor = 0.1f;  //震动频率
    private float radio = 1;        //震动幅度

    void Start()
    {
        mainCamera = Camera.main;
        mCurPos = mainCamera.transform.position;
    }

    void Update()
    {
        ShakeCamera_Time();
    }

    void ResetShakeTime()
    {
        shakeTime = 2f;
    }

    void ShakeCamera_Time()
    {
        if (shakeTime > 0)
        {
            mainCamera.transform.position = mCurPos + Random.insideUnitSphere * radio;
            shakeTime -= Time.deltaTime * deFactor;
        }
        else
        {
            shakeTime = 0;
            mainCamera.transform.position = mCurPos; 
        }
    }
}
