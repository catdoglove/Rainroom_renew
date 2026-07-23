using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadEvtf : MonoBehaviour
{
    AsyncOperation async;
    int i = 0;
    //카메라 태그로 찾고 적용
    public GameObject menu_obj;
    public Camera camera_c;

    // Use this for initialization
    void Start()
    {

    }
    IEnumerator Load()
    {
        async = SceneManager.LoadSceneAsync("Main");
        yield return async; // AsyncOperation 자체가 YieldInstruction이라 완료될 때까지 자동 대기
    }



    // Update is called once per frame
    void Update()
    {
        i++;
        if (i == 200)
        {
            StartCoroutine(Load());
        }
    }
    



}
