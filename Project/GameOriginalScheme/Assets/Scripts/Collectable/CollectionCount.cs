using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;


public class CollectionCount : MonoBehaviour
{

    public static List<bool> CurrentCollection;

    public static List<bool> Collection;

    void Awake()
    {
        CurrentCollection = new List<bool>();
        Collection = new List<bool>();

        if (File.Exists(Application.persistentDataPath + PlayerData.fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + PlayerData.fileName, FileMode.Open);
            Save save = bf.Deserialize(fs) as Save;
            fs.Close();

            if (save.Collections.Count > 0)
            {
                Collection = save.Collections;
            }
            else
            {
//                Debug.Log("no collection");
                Collection.Clear();
                for (int i = 0; i < 9; i++)
                {
                    Collection.Add(false);
                }
            }

            if (LoadGame.Loaded && save.CurrentCollection.Count > 0)
            {
                CurrentCollection = save.CurrentCollection;
            }
            else
            {
//                Debug.Log("no current");
                CurrentCollection.Clear();
                for (int i = 0; i < 9; i++)
                {
                    CurrentCollection.Add(false);
                }
            }
            //CollectionState = save.CurrentCollection;
            //if (save.Collections.Capacity != 0)
            //{
            //    Collections = save.Collections;

            //}

            //Levels = save.Levels;
            //Collections = save.Collections;
            //Debug.Log(save.PrincessPosition);
            //Debug.Log(save.Collections);
            //Debug.Log(save.PrincessPos);
        }
        else
        {
            Collection.Clear();
            for (int i = 0; i < 9; i++)
            {
                Collection.Add(false);
            }
            CurrentCollection.Clear();
            for (int i = 0; i < 9; i++)
            {
                CurrentCollection.Add(false);
            }
            //Debug.Log(Application.persistentDataPath + PlayerData.fileName);

            //Debug.Log("No Saves");
        }
        //CurrentCollection.Clear();
        //for (int i = 0; i < 9; i++)
        //{
        //    //CollectionCount.Collections.Add(false);
        //    CurrentCollection.Add(false);
        //}

        //if (LoadGame.Loaded || LoadGame.Collections.Capacity != 0)
        //{
        //    CurrentCollection = LoadGame.CollectionState;
        //    //LoadGame.Loaded = false;
        //    Collection = LoadGame.Collections;
        //}
        //else
        //{
        //    Collection.Clear();
        //    for (int i = 0; i < 9; i++)
        //    {
        //        //CollectionCount.Collections.Add(false);
        //        Collection.Add(false);
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
//        Debug.Log(LoadGame.Collections.Count);
    }
}
