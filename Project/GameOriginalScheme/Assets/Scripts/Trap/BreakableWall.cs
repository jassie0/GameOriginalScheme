using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour {
	public GameObject OriginalWall;
	public GameObject BrokenWall;

	public void WallChange () {
		OriginalWall.SetActive (false);
		BrokenWall.SetActive (true);
	}
}
