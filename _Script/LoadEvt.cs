using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadEvt : MonoBehaviour
{
    AsyncOperation async;
    int i = 0;
    // Use this for initialization
    void Start()
    {


    }
    IEnumerator Load()
    {
        if (PlayerPrefs.GetInt("scene", 0) == 2)
        {
            async = SceneManager.LoadSceneAsync("Park");
        }
        else if (PlayerPrefs.GetInt("scene", 0) == 3)
        {
            async = SceneManager.LoadSceneAsync("City");
        }
        else if (PlayerPrefs.GetInt("scene", 0) == 0)
        {
            async = SceneManager.LoadSceneAsync("Main");
        }
        else
        {
            async = SceneManager.LoadSceneAsync("Main");
        }


        while (!async.isDone)
        {

            yield return true;
        }
    }





    // Update is called once per frame
    void Update()
    {
        i++;
        if (i == 50)
        {
            StartCoroutine(Load());
        }
    }
}
