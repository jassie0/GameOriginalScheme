using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartPlay : UIWindow 
{
	public AudioClip sfxButton;

    private bool oneshotSfx = true;

    private void OnEnable()
    {
        oneshotSfx = true;
    }

    private void OnDisable()
    {
        oneshotSfx = false;
    }

    private void Update () 
    {
        if(oneshotSfx)
        {
            if (Input.anyKeyDown)
            {
                AudioSource.PlayClipAtPoint(sfxButton, Vector3.zero);
                oneshotSfx = false;
                UIControl.Instance().OpenSingleWindow(UI_TYPE.SelectMode);
            }
        }
	}

	//IEnumerator LoadAsyn (){
	//	AsyncOperation operation = SceneManager.LoadSceneAsync (1);
	//	loadingScreen.SetActive (true);
	//	while(!operation.isDone) {
	//		float progress = Mathf.Clamp01 (operation.progress / .9f);
	//		slider.value = progress;
	//		progressText.text = progress * 100 + "%";
	//		yield return null;
	//	}
	//}
		
}
