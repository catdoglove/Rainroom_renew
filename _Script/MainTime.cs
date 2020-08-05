using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTime : MonoBehaviour
{
    string str;
    int talk;

    int wepRnd, wepShow, baqueRnd, baqueShow;
    float moveX, moveY, b_moveX, b_moveY;
    public GameObject wep_obj, baques_obj;
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

            //BaquiWep();
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

    void BaquiWep()
    {

        //거미줄
        if (wepRnd == 1)
        {
            if (wepShow == 0)
            {
                moveX = -8f;
                moveY = -8f;
                wepRnd = 0;
            }
            wepShow = 1;
            wep_obj.SetActive (true);
            wep_obj.transform.position = new Vector3(moveX, moveY, wep_obj.transform.position.z);

        }
        else
        {
            wepRnd = Random.Range(0, 300);
            moveX = Random.Range(-7.1f, 7.1f);
            moveY = Random.Range(-4.1f, 4.1f);
            wep_obj.SetActive (false);
        }


        //바퀴벌레
        
        if (baqueShow == 0)
        {
            baqueRnd = 0;
            b_moveX = -14.5f;

            baques_obj.transform.position = new Vector3(b_moveX, b_moveY, baques_obj.transform.position.z);

            baqueRnd = Random.Range(0, 300);
            if (baqueRnd == 1)
            {
                baqueShow = 1;
            }
        }
        else
        {
            b_moveX = baques_obj.transform.position.x + (0.02f);//(1.5f * Time.deltaTime);
            baques_obj.transform.position = new Vector3(b_moveX, baques_obj.transform.position.y + 0.001f, baques_obj.transform.position.z);
            if (b_moveX > 14)
            {
                baqueShow = 0;
            }
            if (baqueShow == 0)
            {
                baqueRnd = 0;
                b_moveX = -14.5f;
                baques_obj.transform.position = new Vector3(b_moveX, b_moveY, baques_obj.transform.position.z);
            }
        }
        
    }



}
