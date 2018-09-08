using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.SceneManagement;


[Serializable]
public class Save
{
    public List<bool> SceneCollections = new List<bool>();
    public List<bool> Collections = new List<bool>();

    //public Vector3 PrincessPosition = Vector3.zero;
    public int CurrentScene;
    public List<bool> CurrentCollection = new List<bool>();
    public List<float> PrincessPos = new List<float>();
    //public float PosX;
    //public float PosY;
    //public float PosZ;
}

public class PlayerData : MonoBehaviour
{
    public static string fileName = "/gamedata.save";

    //public Transform checkPoint;
    public Vector3 checkPointPos;

    // Use this for initialization
    void Awake()
    {
        //path = "Assets/BP final/Scripts";
        //Debug.Log(path);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void SaveGame()
    //{
    //    string str = JsonUtility.ToJson(CreateSave());
    //    FileStream fileStream = new FileStream(path + fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
    //    //if (!File.Exists(path + fileName))
    //    //{
    //    //    Debug.Log("No Saves");
    //    //    sw = File.CreateText(path + fileName);
    //    //}
    //    //else {

    //    //}
    //    fileStream.SetLength(0);
    //    StreamWriter streamWriter = new StreamWriter(fileStream);
    //    streamWriter.Write(str);
    //    streamWriter.Close();

    //}

    public Save CreateSave()
    {
        Save save = new Save();

        //save.Levels = NextScene.SceneCollection;
        //save.Collections = CollectableObject.Collections;
        //PrincessPosition = transform.position
        save.PrincessPos.Clear();
        save.PrincessPos.Add(checkPointPos.x);
        save.PrincessPos.Add(checkPointPos.y);
        save.PrincessPos.Add(checkPointPos.z);
        save.CurrentScene = SceneManager.GetActiveScene().buildIndex;

        if (GameObject.FindWithTag("Collectable") != null)
        {
            save.CurrentCollection = CollectionCount.CurrentCollection;
            save.Collections = CollectionCount.Collection;
            save.SceneCollections = NextScene.SceneCollection;
        }

        //Debug.Log("saved");
        //Debug.Log("2 + "+CollectionCount.CurrentCollection[2]);
        //Debug.Log("3 + "+CollectionCount.CurrentCollection[3]);

        //foreach(var i in save.CurrentCollection){
        //    Debug.Log(i);
        //}

       
        //Debug.Log(save.Collections.Capacity + " save capacity");
        //Debug.Log("save 2 "+save.Collections[2]);
        //Debug.Log("save 3 "+save.Collections[3]);
        //for (int i = 0; i < 9; i++)
        //{
        //    if (CollectionCount.CurrentCollection[i] == true)
        //    {
        //        LoadGame.Collections[i] = true;
        //    }
        //    save.Collections.Add(false);
        //    save.Collections[i] = LoadGame.Collections[i];
        //}

        return save;
    }

    public void SaveGame()
    {
        Save save = CreateSave();
        //Debug.Log(Application.persistentDataPath + fileName);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Create(Application.persistentDataPath + fileName);
        bf.Serialize(fs, save);
        //Debug.Log(save.Collections[0]);
        //Debug.Log(save.Collections[1]);
//        Debug.Log("saved");

        fs.Close();
    }


}
