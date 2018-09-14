using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour {
	public float interval = 1.5f;
	public float arrowSpeed = 5f;
	public Transform arrowPrefab;
	public bool checkRun = true;
	public GameObject[] arrowActivator;
	public Sprite trapOff;
	public Sprite trapOn;
	public Transform arrowSpawnPoint;
	//private IEnumerator coroutine; 
	//Coroutine lastRoutine = null;
	// Use this for initialization
	void Start () {
		if (arrowActivator.Length == 0) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = trapOn;
			StartCoroutine (ShootArrow());
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < arrowActivator.Length; i++) {
            //以后别在Update里面循环GetComponent，而且Get之后需要判空防止报错
            MachineTrigger arrowAct = arrowActivator[i].GetComponent<MachineTrigger>();
            if (arrowAct != null)
            {
                if (arrowAct.machineOn)
                {
                    if (checkRun == true)
                    {
                        gameObject.GetComponent<SpriteRenderer>().sprite = trapOn;
                        StartCoroutine(ShootArrow());
                        checkRun = false;
                    }
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = trapOff;
                    StopAllCoroutines();
                    checkRun = true;
                }
                 
            }

            /*
            if (arrowActivator[i].GetComponent<MachineTrigger> ().machineOn == true && checkRun == true) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = trapOn;
				StartCoroutine (ShootArrow());
				//lastRoutine = StartCoroutine (ShootArrow());
				checkRun = false;
			} else if (arrowActivator[i].GetComponent<MachineTrigger> ().machineOn == false) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = trapOff;
				StopAllCoroutines ();
				checkRun = true;
			}*/
		}
	}

	IEnumerator ShootArrow() {
		Transform arrow= Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowPrefab.rotation, this.transform.parent);
		arrow.GetComponent<EnemyArrow>().speed = arrowSpeed;
		//SoundManager.Instance().PlaySound("arrowShoot");
		yield return new WaitForSeconds(interval);
		StartCoroutine(ShootArrow());
	}
}
