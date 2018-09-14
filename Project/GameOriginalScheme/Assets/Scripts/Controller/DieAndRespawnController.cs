using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Gamekit2D;

public class DieAndRespawnController : MonoBehaviour {

    public bool Invulnerable = false;
    [Range(1f, 10f)]
    public float RespawnTime = 1f;
    public Checkpoint m_lastCheckpoint;

    public bool Alive = true;
    PlayerData playerData;

    Vector3 originalPosition;

    [System.Serializable]
    public class DieAndRespawnEvent : UnityEvent
    { }
    [SerializeField]
    public DieAndRespawnEvent OnDie;
    [SerializeField]
    public DieAndRespawnEvent OnRespawn;

    // Use this for initialization
    void Start() {
        playerData = GetComponent<PlayerData>();
        originalPosition = transform.position;

        if (LoadGame.RespawnPos != Vector3.zero && LoadGame.Loaded)
        {
            //Debug.Log(LoadGame.Loaded);

            transform.position = LoadGame.RespawnPos;
        }
    }

    // Update is called once per frame
    void Update() {
		if (GetComponent<CharacterHealth> ().health <= 0) {
			if (Alive && !Invulnerable)
			{
				Alive = false;
				OnDie.Invoke();
				Invoke("Respawn", RespawnTime);
			}
		}
    }
		
    
    public void SetCheckpointTransform(Checkpoint checkPoint)
    {
  
        m_lastCheckpoint = checkPoint;
        playerData.SaveGame();
    }
    public void SetCheckpoint(Checkpoint checkPoint)
    {
        if (Alive)
        {
            
            m_lastCheckpoint = checkPoint;
            //            Debug.Log("Checkponint set:" + checkPoint.transform.position);
            playerData.checkPointPos = checkPoint.transform.position;
            playerData.SaveGame();
        }
    }

    public void Respawn()
    {
        OnRespawn.Invoke();
        if (m_lastCheckpoint != null)
        {
            transform.SetPositionAndRotation(m_lastCheckpoint.transform.position, Quaternion.Euler(0, 0, 0));
        }
        else
        {
            transform.SetPositionAndRotation(originalPosition, Quaternion.Euler(0, 0, 0));
        }
        
 //     Debug.Log("Should Respawn");
        Invulnerable = false;
        Alive = true;
    }
} 

