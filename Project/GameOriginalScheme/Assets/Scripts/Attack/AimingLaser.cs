using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingLaser : MonoBehaviour {
    private LineRenderer lr;

	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        if (hit.collider)
        {
            lr.SetPosition(1, new Vector3(0, hit.distance, 0));
            Debug.Log(hit.distance);
        }
        //else {
          //  lr.SetPosition(1, new Vector3(0, 5000,0));
        //}        
	}
}
