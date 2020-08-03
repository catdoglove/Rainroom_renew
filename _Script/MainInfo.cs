using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainInfo : MonoBehaviour
{
    public GameObject infoWin_obj;
    string str_Code;
    public Text txt_heart;

    // Start is called before the first frame update
    void Start()
    {
        str_Code = PlayerPrefs.GetString("code", "");

    }



    public void infoAct()
    {
        if (infoWin_obj.activeSelf)
        {
            infoWin_obj.SetActive(false);
        }
        else
        {
            infoWin_obj.SetActive(true);
            PlayerPrefs.GetInt("lv", 0);
            txt_heart.text = "" + PlayerPrefs.GetInt(str_Code + "h", 0);
        }
    }


}
