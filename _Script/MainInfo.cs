using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainInfo : MonoBehaviour
{
    public GameObject infoWin_obj;
    string str_Code;
    public Text txt_heart,txt_lv;

    //호감도
    public static int like;
    public Slider sld_like;
    public GameObject face;
    public Sprite[] spr_face;
    public Text txt_likeLv, txt_faceLv;
    public GameObject GM;

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

            if (PlayerPrefs.GetInt("scene", 0) == 0)
            {
                GM.GetComponent<MainMenuEvt>().AllClose();
            }
            //SetIofo();
            infoWin_obj.SetActive(true);
            //txt_lv.text = "" + PlayerPrefs.GetInt("likelv", 0);
            txt_heart.text = "" + PlayerPrefs.GetInt(str_Code + "h", 0);
        }
    }


    void SetIofo()
    {

        sld_like.value = like;
        sld_like.maxValue = PlayerPrefs.GetFloat("maxlike", 50);
        if (PlayerPrefs.GetInt("likelv", 0) == 1)
        {
            face.GetComponent<SpriteRenderer>().sprite = spr_face[1];
            txt_likeLv.text = "[다음 호감도 조건]\n꾸준한 대화 및 창문,책 Lv.4이상";
        }
        if (PlayerPrefs.GetInt("likelv", 0) == 2)
        {
            face.GetComponent<SpriteRenderer>().sprite = spr_face[2];
            txt_likeLv.text = "[다음 호감도 조건]\n꾸준한 대화 및 창문,책 Lv.6이상";
        }
        if (PlayerPrefs.GetInt("likelv", 0) == 3)
        {
            face.GetComponent<SpriteRenderer>().sprite = spr_face[3];
            txt_likeLv.text = "[다음 호감도 조건]\n꾸준한 대화 및 창문,책 Lv.8이상";
        }
        if (PlayerPrefs.GetInt("likelv", 0) == 4)
        {
            face.GetComponent<SpriteRenderer>().sprite = spr_face[4];
            txt_likeLv.text = "..할 말이 있어";
        }
        if (PlayerPrefs.GetInt("likelv", 0) == 5)
        {
            face.GetComponent<SpriteRenderer>().sprite = spr_face[5];
            txt_likeLv.text = "고마워 :)";
        }
        if (PlayerPrefs.GetInt("likelv", 0) >= 6)
        {
            face.GetComponent<SpriteRenderer>().sprite = spr_face[5];
            txt_likeLv.text = "고마워 :)";
            txt_faceLv.text = "" + (PlayerPrefs.GetInt("likelv", 0) - 5);
        }



        if (like >= 400 && PlayerPrefs.GetInt("likelv", 0) >= 5 && PlayerPrefs.GetInt("book", 0) >= 8 && PlayerPrefs.GetInt("window", 0) >= 8)
        {
            PlayerPrefs.SetInt("changeT", 4);
            sld_like.maxValue = 415;
            face.GetComponent<SpriteRenderer>().sprite = spr_face[5];
            like = 0;
            PlayerPrefs.SetInt("like", like);
            sld_like.value = like;
            PlayerPrefs.SetFloat("maxlike", sld_like.maxValue);
            PlayerPrefs.SetInt("likelv", PlayerPrefs.GetInt("likelv", 0) + 1);
            //taCk = 0;
            txt_likeLv.text = "고마워 :)";
            //loveBtn.SetActive(true);
        }
        else if (like >= 400 && PlayerPrefs.GetInt("likelv", 0) == 4 && PlayerPrefs.GetInt("book", 0) >= 8 && PlayerPrefs.GetInt("window", 0) >= 8)
        {
            PlayerPrefs.SetInt("changeT", 4);
            sld_like.maxValue = 415;
            face.GetComponent<SpriteRenderer>().sprite = spr_face[5];
            like = 0;
            PlayerPrefs.SetInt("like", like);
            sld_like.value = like;
            PlayerPrefs.SetFloat("maxlike", sld_like.maxValue);
            PlayerPrefs.SetInt("likelv", 5);
            //taCk = 0;
            txt_likeLv.text = "고마워 :)";
            //loveBtn.SetActive(true);
        }
        else if (like >= 350 && PlayerPrefs.GetInt("likelv", 0) == 3 && PlayerPrefs.GetInt("book", 0) >= 8 && PlayerPrefs.GetInt("window", 0) >= 8)
        {
            PlayerPrefs.SetInt("changeT", 4);
            sld_like.maxValue = 415;
            face.GetComponent<SpriteRenderer>().sprite = spr_face[4];
            like = 0;
            PlayerPrefs.SetInt("like", like);
            sld_like.value = like;
            PlayerPrefs.SetFloat("maxlike", sld_like.maxValue);
            PlayerPrefs.SetInt("likelv", 4);
            //taCk = 0;
            txt_likeLv.text = "..할 말이 있어";
            //loveBtn.SetActive(true);
        }
        else if (like >= 240 && PlayerPrefs.GetInt("likelv", 0) == 2 && PlayerPrefs.GetInt("book", 0) >= 6 && PlayerPrefs.GetInt("window", 0) >= 6)
        {
            PlayerPrefs.SetInt("changeT", 3);
            sld_like.maxValue = 360;
            face.GetComponent<SpriteRenderer>().sprite = spr_face[3];
            like = 0;
            PlayerPrefs.SetInt("like", like);
            sld_like.value = like;
            PlayerPrefs.SetFloat("maxlike", sld_like.maxValue);
            PlayerPrefs.SetInt("likelv", 3);
            //taCk = 0;
            txt_likeLv.text = "[다음 호감도 조건]\n꾸준한 대화 및 창문,책 Lv.8이상";
            //loveBtn.SetActive(true);
        }
        else if (like >= 120 && PlayerPrefs.GetInt("likelv", 0) == 1 && PlayerPrefs.GetInt("book", 0) >= 4 && PlayerPrefs.GetInt("window", 0) >= 4)
        {
            PlayerPrefs.SetInt("changeT", 2);
            sld_like.maxValue = 245;
            face.GetComponent<SpriteRenderer>().sprite = spr_face[2];
            like = 0;
            PlayerPrefs.SetInt("like", like);
            sld_like.value = like;
            PlayerPrefs.SetFloat("maxlike", sld_like.maxValue);
            PlayerPrefs.SetInt("likelv", 2);
            //taCk = 0;
            txt_likeLv.text = "[다음 호감도 조건]\n꾸준한 대화 및 창문,책 Lv.6이상";
            //loveBtn.SetActive(true);
        }
        else if (like >= 50 && PlayerPrefs.GetInt("likelv", 0) == 0 && PlayerPrefs.GetInt("book", 0) >= 2 && PlayerPrefs.GetInt("window", 0) >= 2)
        {
            PlayerPrefs.SetInt("changeT", 1);
            sld_like.maxValue = 122;
            face.GetComponent<SpriteRenderer>().sprite = spr_face[1];
            like = 0;
            PlayerPrefs.SetInt("like", like);
            sld_like.value = like;
            PlayerPrefs.SetFloat("maxlike", sld_like.maxValue);
            PlayerPrefs.SetInt("likelv", 1);
            //taCk = 0;
            txt_likeLv.text = "[다음 호감도 조건]\n꾸준한 대화 및 창문,책 Lv.4이상";
            //loveBtn.SetActive(true);
        }
    }


}
