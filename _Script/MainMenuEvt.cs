using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuEvt : MonoBehaviour
{
    public GameObject menu_obj,option_obj;
    public GameObject muteImg_obj, muteBGImg_obj;
    public Sprite[] mute_spr;

    public GameObject GM;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    



    //메뉴창 닫기 열기
    public void ActMenu()
    {

        if (menu_obj.activeSelf)
        {
            menu_obj.SetActive(false);
        }
        else
        {
            menu_obj.SetActive(true);
        }
    }

    //옵션창 닫기 열기
    public void ActOption()
    {

        if (GM == null)
        {
            GM = GameObject.FindGameObjectWithTag("GMS");
        }

        if (option_obj.activeSelf)
        {
            option_obj.SetActive(false);
        }
        else
        {
            option_obj.SetActive(true);
        }
    }
    
    public void MuteBG()
    {
        if (PlayerPrefs.GetInt("soundBGmute", 0) == 1)
        {
            PlayerPrefs.SetInt("soundBGmute", 0);
            GM.GetComponent<SoundEvt>().BGMute();
            muteBGImg_obj.GetComponent<Image>().sprite = mute_spr[0];
        }
        else
        {
            PlayerPrefs.SetInt("soundBGmute", 1);
            GM.GetComponent<SoundEvt>().BGMute();
            muteBGImg_obj.GetComponent<Image>().sprite = mute_spr[1];
        }
        PlayerPrefs.Save();
    }
    public void MuteSE()
    {
        if (PlayerPrefs.GetInt("soundmute", 0) == 1)
        {
            GM.GetComponent<SoundEvt>().soundMute();
            muteBGImg_obj.GetComponent<Image>().sprite = mute_spr[0];
        }
        else
        {
            GM.GetComponent<SoundEvt>().soundMute();
            muteBGImg_obj.GetComponent<Image>().sprite = mute_spr[1];
        }
        PlayerPrefs.Save();
    }
}
