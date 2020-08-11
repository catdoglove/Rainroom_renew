using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveOut : MonoBehaviour
{
    string str_Code;
    public GameObject toast;
    public Text toastTxt;
    // Start is called before the first frame update
    void Start()
    {

        str_Code = PlayerPrefs.GetString("code", "");
        
    }
    

    public void GoOutCity()
    {
        int h = PlayerPrefs.GetInt(str_Code + "h", 0);
        if (h >= 100)
        {
            h = h - 100;
            PlayerPrefs.SetInt(str_Code + "h", h);
            PlayerPrefs.SetInt("gocitysuccess", 1);
            PlayerPrefs.SetString("outtime", System.DateTime.Now.ToString());
            PlayerPrefs.SetInt("scene", 3);

            SceneManager.LoadSceneAsync("city");
        }
        else
        {
            toast.SetActive(true);
            toastTxt.text = "마음이 부족하다.";
        }
    }

    public void GoOutPark()
    {
        int h = PlayerPrefs.GetInt(str_Code + "h", 0);
        if (h >= 100)
        {
            h = h - 100;
            PlayerPrefs.SetInt(str_Code + "h", h);
            PlayerPrefs.SetString("outtime", System.DateTime.Now.ToString());
            PlayerPrefs.SetInt("scene", 2);
            SceneManager.LoadSceneAsync("park");
        }
        else
        {
            toast.SetActive(true);
            toastTxt.text = "마음이 부족하다.";
        }
    }


}
