using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadGame : MonoBehaviour
{

    public static Vector3 RespawnPos;
    //public static List<bool> CollectionState = new List<bool>();
    public static bool Loaded;
    public GameObject WithSave;
    public GameObject Savee;

    //public static List<bool> Levels = new List<bool>();
    //public static List<bool> Collections = new List<bool>();

    // Use this for initialization
    void Awake()
    {
        //Debug.Log(Application.persistentDataPath + PlayerData.fileName);
        //Debug.Log(File.Exists(Application.persistentDataPath + PlayerData.fileName));
        if (!File.Exists(Application.persistentDataPath + PlayerData.fileName))
        {
            gameObject.SetActive(false);
            Savee.SetActive(false);
            WithSave.SetActive(true);

        }
        //if (Collections.Capacity == 0)
        //{
        //    for (int i = 0; i < 9; i++)
        //    {
        //        Collections.Add(false);
        //        //Debug.Log(Collections[i]);
        //    }
        //}


    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Collections.Count);
    }

    public void LoadG()
    {
        if (File.Exists(Application.persistentDataPath + PlayerData.fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + PlayerData.fileName,FileMode.Open);
            Save save = bf.Deserialize(fs) as Save;
            fs.Close();

            Loaded = true;

            Loading.sceneIndex = save.CurrentScene;
            SceneManager.LoadScene("Loading");
            RespawnPos = new Vector3(save.PrincessPos[0],
                                     save.PrincessPos[1],
                                     save.PrincessPos[2]);
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
            //Debug.Log(Application.persistentDataPath + PlayerData.fileName);

            //Debug.Log("No Saves");
        }

    }

    public Vector3 Parse(string name)
    {
        name = name.Replace("(", "").Replace(")", "");
        string[] s = name.Split(',');
        return new Vector3(float.Parse(s[0]), float.Parse(s[1]), float.Parse(s[2]));
    }


}