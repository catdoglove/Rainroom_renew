using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepEvt : MonoBehaviour
{

    public int minute, hours;
    string lastTime, str_Code;
    public Text sleepTime_txt;
    public GameObject dreamWin_obj,sleepYN_obj,sleepBack_obj,dreamnote_obj,bedWin_obj;
    public GameObject sleepDown_obj, sleepUp_obj, bed_obj;
    public Animator Ani_sleep;

    // Start is called before the first frame update
    void Start()
    {

        str_Code = PlayerPrefs.GetString("code", "");

        StartCoroutine("SleepTime");
        if (PlayerPrefs.GetInt("sleeping", 0) == 0)
        {
            if (PlayerPrefs.GetInt("sleepdream", 0) == 1)
            {
                dreamnote_obj.SetActive(true);
            }
        }
        else
        {

            sleepBack_obj.SetActive(true);
            bed_obj.SetActive(false);
            sleepMove();
        }
    }

    void SleepAni()
    {
        if (PlayerPrefs.GetInt("bedlv", 0) >= 3)
        {
            Ani_sleep.Play("sleep");
        }
    }


    //깨어날시간 체크
    IEnumerator SleepTime()
    {
        int a = 0;
        while (a == 0)
        {
            if (PlayerPrefs.GetInt("sleeping", 0) == 1)
            {

            SleepTimeFlow();
            if (minute <= 0 && hours == 0)
            {
                hours = -1;
            }

            string str = string.Format(@"{00:00}" + ":", hours) + string.Format(@"{00:00}", minute);
            if (hours <= 0)
            {
                sleepTime_txt.text = "00:00";
                PlayerPrefs.SetInt("sleeping", 0);
            }
            else
            {
                sleepTime_txt.text = str;
            }
            PlayerPrefs.Save();
            }
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
    public void OpenSleepYN()
    {
        bedWin_obj.SetActive(true);
    }
    public void OpenSleepYNY()
    {
        sleepYN_obj.SetActive(true);
        bedWin_obj.SetActive(false);
    }
    public void OpenSleepYNN()
    {
        bedWin_obj.SetActive(false);
    }

    //잘까?
    public void SleepY()
    {
        PlayerPrefs.SetString("sleepLastTime", System.DateTime.Now.ToString());
        sleepYN_obj.SetActive(false);
        sleepBack_obj.SetActive(true);
        PlayerPrefs.SetInt("sleeping", 1);
        PlayerPrefs.SetInt("sleepdream", 1);
        sleepMove();
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
            PlayerPrefs.SetInt("sleepdream", 0);
            int r = PlayerPrefs.GetInt(str_Code + "r", 0);
            int h = PlayerPrefs.GetInt(str_Code + "h", 0);
            r = r + 400;
            h = h + 27;
            PlayerPrefs.SetInt(str_Code + "r", r);
            PlayerPrefs.SetInt(str_Code + "h", h);
        }
    }

    //잠잘때 애니메이션 띄우기
    void sleepMove()
    {
        if (PlayerPrefs.GetInt("bedlv", 0)==1)
        {
            sleepDown_obj.SetActive(true);
        }
        else
        {
            sleepUp_obj.SetActive(true);
            bed_obj.SetActive(true);
        }
    }
    
    
}
