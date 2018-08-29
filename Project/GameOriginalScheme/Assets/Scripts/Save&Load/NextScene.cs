using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{

    //public string sceneName;
    public static List<bool> SceneCollection;
    public int sceneNum;

    // Use this for initialization
    void Awake()
    {
        SceneCollection = new List<bool>();

        if (File.Exists(Application.persistentDataPath + PlayerData.fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + PlayerData.fileName, FileMode.Open);
            Save save = (Save)bf.Deserialize(fs);
            fs.Close();

            //Loaded = true;
            if (save.SceneCollections.Count > 0)
            {
                SceneCollection = save.SceneCollections;
            }
            else
            {
                SceneCollection.Clear();
                for (int i = 0; i < 6; i++)
                {
                    SceneCollection.Add(false);
                }
            }

            //SceneManager.LoadScene(save.CurrentScene);
            //RespawnPos = new Vector3(save.PrincessPos[0],
            //                       save.PrincessPos[1],
            //                       save.PrincessPos[2]);
            //CollectionState = save.CurrentCollection;
            //Debug.Log(save.PrincessPosition);
            //Debug.Log(save.Collections);
            //Debug.Log(save.PrincessPos);
        }
        else
        {
            SceneCollection.Clear();
            for (int i = 0; i < 6; i++)
            {
                SceneCollection.Add(false);
            }
            Debug.Log("No Saves");
        }
        //SceneCollection.Add(true);

        //for (int i = 0; i < 4; i++)
        //{
        //    SceneCollection.Add(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(SceneCollection.Count);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        //Destroy Animation

    //        ShowDialogue();

    //        gameObject.SetActive(false);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("collider");
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("l2");
            //SceneCollection[sceneNum] = true;

            Loading.sceneIndex = sceneNum;
            SceneManager.LoadScene("Loading");


            Debug.Log(SceneCollection.Count);
            if (SceneCollection.Count > 0)
            {
                if (SceneManager.GetActiveScene().buildIndex < SceneCollection.Count)
                {
                    SceneCollection[SceneManager.GetActiveScene().buildIndex] = true;

                }
                if (sceneNum < SceneCollection.Count)
                {
                    SceneCollection[sceneNum] = true;
                }

            }
        }
    }
}
