using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    
    public class Reload : MonoBehaviour
    {
        public GameObject player;
        //public GameObject[] traps;
        //public GameObject[] zones;
		public GameObject[] enemies;

        [SerializeField]
        private Vector3[] originalTransforms;
        private Vector3[] originalRotations;
        private Vector3[] originalZoneTransforms;

        // Use this for initialization
        void Awake()
        {
            player = GameObject.FindWithTag("King");
           // zones = GameObject.FindGameObjectsWithTag("Zone");
			enemies = GameObject.FindGameObjectsWithTag("Enemy");
            //traps = GameObject.FindGameObjectsWithTag("Trap");


			originalTransforms = new Vector3[enemies.Length];
//            originalRotations = new Vector3[traps.Length];
            //originalZoneTransforms=new Vector3[zones.Length];
//            for (int i = 0; i < traps.Length; i++)
//            {
//                //            Debug.Log("Player Number " + i + " is named " );
//                originalTransforms[i] = traps[i].transform.position;
//            }
//            for (int i = 0; i < traps.Length; i++)
//            {
//                //            Debug.Log("Player Number " + i + " is named " );
//                originalRotations[i] = traps[i].transform.eulerAngles;
//            }

//            for (int i = 0; i < zones.Length; i++)
//            {
//                //            Debug.Log("Player Number " + i + " is named " );
//                originalZoneTransforms[i] = zones[i].transform.position;
//            }
        }

        // Update is called once per frame

        public void reload()
        {

            StartCoroutine(Wait());

        }
        IEnumerator Wait()
        {
            yield return null;
			for (int i = 0; i < enemies.Length; i++){
//				while(enemies[i].activeSelf){
//					enemies [i].SetActive (false);
//				}

				enemies [i].transform.position = originalTransforms [i];
			}
//            for (int i = 0; i < traps.Length; i++)
//            {
//                while(traps[i].activeSelf){
//                    traps[i].SetActive(false);
//                }
//
//
//                traps[i].SetActive(true);
//                traps[i].transform.eulerAngles= originalRotations[i];
//                traps[i].transform.position = originalTransforms[i];
//                traps[i].GetComponent<Damager>().enabled = false;
//                if(traps[i].GetComponent<Bird>()){
//                    traps[i].GetComponent<Bird>().setStartFalse();
//                }
//               
//
//            }
//            for (int i = 0; i < zones.Length; i++)
//            {
//                while (zones[i].activeSelf)
//                {
//                    zones[i].SetActive(false);
//                }
//
//                zones[i].SetActive(true);
//                zones[i].transform.position = originalZoneTransforms[i];
//                zones [i].GetComponent<Damager> ().enabled = true;
//
//            }

        }
    }
}