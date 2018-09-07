using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueCollection : MonoBehaviour {
	public GameObject dialogue;
	public string[] words = { "a", "b", "c" };
	int index;
	Text dlgText;
	// Use this for initialization
	void Start () {
		dialogue.SetActive(false);
		dlgText = dialogue.GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "King")
		{
			//Destroy Animation

			ShowDialogue();

			gameObject.SetActive(false);
		}
	}

	void ShowDialogue()
	{
		dialogue.SetActive(true);
		if (words.Length != 0)
		{
			dlgText.text = words[0];
			index++;
		}
		//Time.timeScale = 0;
	}

	public void DisableDialogue()
	{
		if (index < words.Length)
		{
			dlgText.text = words[index];
			index++;
		}
		else
		{
			//Time.timeScale = 1;
			dialogue.SetActive(false);
		}
	}
}
