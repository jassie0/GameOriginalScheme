using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaText : MonoBehaviour {
	public float speedFade;
	private float count;
	public Text text;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {


		//Fade in-out press start
		count += speedFade * Time.deltaTime;

		text.color = new Color(0.8f,0.8f,0.8f,Mathf.Sin(count)*0.8f);

	}

}
