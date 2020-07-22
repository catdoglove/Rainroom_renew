using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepEvt : MonoBehaviour
{

    public int minute, hours;
    string lastTime;
    public Text sleepTime_txt;
    public GameObject dreamWin_obj,sleepYN_obj,sleepBack_obj;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SleepTime");

    }


    //깨어날시간 체크
    IEnumerator SleepTime()
    {
        int a = 0;
        while (a == 0)
        {


            SleepTimeFlow();
            if (minute <= 0 && hours == 0)
            {
                hours = -1;
            }

            string str = string.Format(@"{0:00}" + ":", hours) + string.Format(@"{0:00}", minute);
            if (hours <= 0)
            {
                sleepTime_txt.text = "00:00";
            }
            else
            {
                sleepTime_txt.text = str;
            }

            PlayerPrefs.Save();
            yield return new WaitForSeconds(1f);
        }

    }



    //얼마나 시간이 흘렀나?
    void SleepTimeFlow()
    {
        System.DateTime d = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
        lastTime = PlayerPrefs.GetString("sleepLastTime", d.ToString());
        System.DateTime lastDateTime = System.DateTime.Parse(lastTime);
        System.TimeSpan compareTime = System.DateTime.Now - lastDateTime;
        hours = (int)compareTime.TotalHours;
        minute = (int)compareTime.TotalMinutes;
        minute = minute - (minute / 60) * 60;
        minute = 59 - minute;
        hours = 5 - hours;
        if (minute < 0)
        {
        }
    }

    //잘까?
    public void SleepY()
    {
        sleepYN_obj.SetActive(false);
        sleepBack_obj.SetActive(true);
        PlayerPrefs.SetInt("sleeping", 1);
    }

    public void SleepN()
    {
        sleepYN_obj.SetActive(false);
    }

    //꿈일기 창띄우기닫기
    public void ActDream()
    {
        if (dreamWin_obj.activeSelf)
        {
            dreamWin_obj.SetActive(false);
        }
        else
        {
            dreamWin_obj.SetActive(true);
        }
        
    }

    

}
