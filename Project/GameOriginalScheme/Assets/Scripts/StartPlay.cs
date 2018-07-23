using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartPlay : MonoBehaviour {

	public AudioClip sfxButton;

	private bool oneshotSfx;

	public GameObject loadingScreen;
	public Slider slider;
	public Text progressText;
	// Update is called once per frame
	void Update () {

		//if press any key jump to gameplay scene
		if(Input.anyKeyDown)
		{
			if(!oneshotSfx)
			{
				AudioSource.PlayClipAtPoint(sfxButton,Vector3.zero);
				StartCoroutine (LoadAsyn());
				oneshotSfx = true;
			}


		}

	}



	IEnumerator LoadAsyn (){
		AsyncOperation operation = SceneManager.LoadSceneAsync (1);
		loadingScreen.SetActive (true);
		while(!operation.isDone) {
			float progress = Mathf.Clamp01 (operation.progress / .9f);
			slider.value = progress;
			progressText.text = progress * 100 + "%";
			yield return null;
		}
	}
		
}
