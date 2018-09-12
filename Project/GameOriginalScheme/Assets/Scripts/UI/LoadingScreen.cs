using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : UIWindow
{
    public Slider slider;
    public Text progressText;

    public override void Open()
    {
        base.Open();
        transform.SetAsLastSibling();
    }

    public override void SetWindow(string data)
    {
        base.SetWindow(data);
        StartCoroutine(LoadAsyn(data));
    }

    IEnumerator LoadAsyn(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            slider.value = progress;
            progressText.text = Mathf.CeilToInt(progress * 100).ToString() + "%";
            yield return null;
        }

        //yield return new WaitForSeconds(1f);

        GameController.instance.SetInFightScene(true);
        Close();
        //UIControl.instance.CloseWindow(UI_TYPE.Loading);
    }

    private void OnDisable()
    {
        slider.value = 0f;
    }
}
