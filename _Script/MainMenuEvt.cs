using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuEvt : MonoBehaviour
{
    public GameObject menu_obj,option_obj, menuOut_obj, menuIn_obj;
    public GameObject muteImg_obj, muteBGImg_obj;
    public Sprite[] mute_spr;

    public GameObject GM,GMD;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("scene", 0);
    }
    



    //메뉴창 닫기 열기
    public void ActMenu()
    {
        if(PlayerPrefs.GetInt("scene", 0) == 0)
        {
            if (GM == null)
            {
                GM = GameObject.FindGameObjectWithTag("GameObject");
            }

            menu_obj = menuIn_obj;
        }
        else
        {
            menu_obj = menuOut_obj;
        }

        if (menu_obj.activeSelf)
        {
            menu_obj.SetActive(false);
        }
        else
        {
            AllClose();
            menu_obj.SetActive(true);
        }
    }

    //옵션창 닫기 열기
    public void ActOption()
    {
        
        if (PlayerPrefs.GetInt("scene", 0) == 0)
        {
            if (GM == null)
            {
                GM = GameObject.FindGameObjectWithTag("GameObject");
            }
        }

        if (option_obj.activeSelf)
        {
            option_obj.SetActive(false);
        }
        else
        {
            AllClose();
            option_obj.SetActive(true);
        }
    }

    //상점창
    public void GetActShop()
    {
        AllClose();
        GM.GetComponent<MainShop>().shopAct();
    }

    //구독
    public void GetActNews()
    {
        AllClose();
        GM.GetComponent<MainTime>().gudocOpen();
    }

    //전단창
    public void GetActBeadal()
    {
        AllClose();
        GM.GetComponent<MainTime>().ActBeadal();
    }


    public void GoBack()
    {
        //SceneManager.LoadSceneAsync("Main");
        SceneManager.LoadSceneAsync("Load");
        PlayerPrefs.SetInt("scene", 0);
    }

    public void MuteBG()
    {

        if (PlayerPrefs.GetInt("scene", 0) == 0)
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
        }
        PlayerPrefs.Save();
    }
    public void MuteSE()
    {

        if (PlayerPrefs.GetInt("scene", 0) == 0)
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
        }
        PlayerPrefs.Save();
    }


    public void AllClose()
    {
        GMD.GetComponent<MainInfo>().infoWin_obj.SetActive(false);
        option_obj.SetActive(false);
        GM.GetComponent<MainShop>().shopWin_obj.SetActive(false);
        GM.GetComponent<MainShop>().outItem_obj.SetActive(false);
        GM.GetComponent<MainShop>().shopWinYN_obj.SetActive(false);
    }

    /*
    public void changeToastTxt()
    {
        if (endck == 1)
        {
            endTxt.text = "종료메세지A";
            AndroidDialogAndToastBinding.instance.toastShort("기본인사로 변경되었습니다.");
            endck = 2;
            Movebtn.opOp = 0;
        }
        else if (endck == 2)
        {
            endTxt.text = "종료메세지B";
            AndroidDialogAndToastBinding.instance.toastShort("호감도에 따른 인사로 변경되었습니다.");
            endck = 1;
            Movebtn.opOp = 0;
        }
        PlayerPrefs.SetInt("endck", endck);
    }
    */
}
