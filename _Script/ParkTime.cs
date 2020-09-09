using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkTime : MonoBehaviour
{

    string str;
    // Start is called before the first frame update
    void Start()
    {

        str = PlayerPrefs.GetString("code", "");
        StartCoroutine("updateSecp");
    }

    IEnumerator updateSecp()
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


}
