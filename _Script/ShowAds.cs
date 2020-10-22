using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAds : MonoBehaviour
{
    public GameObject adWin_obj;
    

    public GameObject tvImg;
    public Sprite[] spr_adTV;


    System.DateTime now;
    System.DateTime lastDateTimenow;
    string lastTimem;

    int ag, agb;

    public GameObject delBtn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ActAd()
    {
        if (adWin_obj.activeSelf)
        {
            adWin_obj.SetActive(false);
        }
        else
        {
            adWin_obj.SetActive(true);
        }
    }


    void Adtime()
    {
        
        now = new System.DateTime(1980, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
        lastTimem = PlayerPrefs.GetString("adtimes", now.ToString());
        System.DateTime lastDateTimem = System.DateTime.Parse(lastTimem);
        System.TimeSpan compareTimem = System.DateTime.Now - lastDateTimem;
        ag = (int)compareTimem.TotalMinutes;
        agb = (int)compareTimem.TotalSeconds;
        agb = agb - (agb / 60) * 60;
        agb = 59 - agb;
        ag = 4 - ag;
        
        if (ag < 0)
        {
            if (PlayerPrefs.GetInt("roomads",0)==0)
            {
                tvImg.GetComponent<Image>().sprite = spr_adTV[1];
                PlayerPrefs.SetInt("roomads", 1);
            }
            else
            {
                tvImg.GetComponent<Image>().sprite = spr_adTV[0];
                PlayerPrefs.SetInt("roomads", 0);
            }
        }
        else
        {

        }
    }

    public void AdReward()
    {
        lastDateTimenow = System.DateTime.Now;
        PlayerPrefs.SetString("adtimes", lastDateTimenow.ToString());
        PlayerPrefs.SetInt("talk", 5);
        adWin_obj.SetActive(false);
    }



    //
    IEnumerator updateSec()
    {
        int a = 0;
        while (a == 0)
        {
            Adtime();

            PlayerPrefs.Save();
            yield return new WaitForSeconds(0.8f);
        }
    }
}
