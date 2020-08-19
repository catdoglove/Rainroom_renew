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


    public Text txt_Popup;
    public GameObject shopPopup_obj;
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

            SceneManager.LoadSceneAsync("City");
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
            SceneManager.LoadSceneAsync("Park");
        }
        else
        {
            toast.SetActive(true);
            toastTxt.text = "마음이 부족하다.";
        }
    }

    public void GoBack()
    {
        SceneManager.LoadSceneAsync("Main");
    }
    public void GoOutYN()
    {
        shopPopup_obj.SetActive(true);
        txt_Popup.text = "별로 나가고 싶지 않은 것 같다.\n더 친해지면 나갈지도 모른다.";
    }


}
