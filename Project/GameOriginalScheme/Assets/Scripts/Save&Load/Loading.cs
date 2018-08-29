using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

    AsyncOperation async;
    public static int sceneIndex = 6;

    // Use this for initialization
    void Start()
    {

        StartCoroutine("LoadScene");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoadScene()
    {

        async = SceneManager.LoadSceneAsync(sceneIndex);

        yield return async;
    }
}
