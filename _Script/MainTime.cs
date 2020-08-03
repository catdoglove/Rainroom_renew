using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTime : MonoBehaviour
{
    string str;
    int talk;

    // Start is called before the first frame update
    void Start()
    {
        //업데이트대신쓴다
        str = PlayerPrefs.GetString("code", "");
        StartCoroutine("updateSec");

        talk = PlayerPrefs.GetInt("talk", 5);
    }


    //
    IEnumerator updateSec()
    {
        int a = 0;
        while (a == 0)
        {
            //최대량 제한 빗물 마음
            if (PlayerPrefs.GetInt(str + "r", 0) > 999999)
            {
                PlayerPrefs.SetInt(str + "r", 999999);
            }

            if (PlayerPrefs.GetInt(str + "h", 0) > 99999)
            {
                PlayerPrefs.SetInt(str + "h", 99999);
            }
            
            PlayerPrefs.Save();
            yield return new WaitForSeconds(1f);
        }
    }


    public void talkBtn()
    {
        talk--;
        if (talk <= 0)
        {
            talk = 0;
        }
        if (talk >= 5)
        {
            talk = 4;
        }
        PlayerPrefs.SetInt("talk", talk);
    }




}
