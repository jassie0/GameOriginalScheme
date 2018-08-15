﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchorAnim : MonoBehaviour {
	PlayerController playerController;
	Animator animator;
	// Use this for initialization
	void Start () {
        GameObject King = GameController.instance.Player;
		playerController = King.GetComponent<PlayerController> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat ("WalkX", Input.GetAxisRaw("Horizontal"));
		animator.SetFloat ("WalkY", Input.GetAxisRaw("Vertical"));
		animator.SetBool ("PlayerMoving", playerController.playerMoving);
		animator.SetFloat ("LastMoveX", playerController.lastMove.x);
		animator.SetFloat ("LastMoveY", playerController.lastMove.y);     
	}
}
