using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parkshop : MonoBehaviour
{


    //무인상점
    public GameObject shop_fst, shop_sec;
    public Text[] txt_fst, txt_sec;
    public Sprite[] spr_shops;
    public int[] cost_clock, cost_draw, cost_frame;
    public string[] str_clock, str_draw, str_frame;
    int shop_rnd;
    int item_num;
    int fstBuy, secBuy;

    public Text txt_rain, txt_Popup;
    public GameObject popUp_obj,shopWin_obj,helpWin_obj;

    int cost_r, cost_h, level, sum, have_r, have_h;

    string str_Code;

    // Start is called before the first frame update
    void Start()
    {

        shop_rnd = Random.Range(0, 3);
        str_Code = PlayerPrefs.GetString("code", "");

        shop();
    }

    public void ActShop()
    {

        if (shopWin_obj.activeSelf)
        {
            shopWin_obj.SetActive(false);
        }
        else
        {
            shopWin_obj.SetActive(true);
            txt_rain.text = "" + PlayerPrefs.GetInt(str_Code + "r", 0);
        }
    }

    public void ShopHelp()
    {
        if (helpWin_obj.activeSelf)
        {
            helpWin_obj.SetActive(false);
        }
        else
        {

            txt_Popup.text = "구입하기에는\n가지고 있는 것이 부족하다.";
            helpWin_obj.SetActive(true);
        }
    }
    
    void shop()
    {

        switch (shop_rnd)
        {
            case 0: //시계액자
                shop_fst.GetComponent<Image>().sprite = spr_shops[0];
                shop_sec.GetComponent<Image>().sprite = spr_shops[2];

                item_num = PlayerPrefs.GetInt("clock", 0);
                if (item_num == 5)
                {
                    txt_fst[0].text = "Lv.MAX";
                    txt_fst[1].text = "품절";
                    txt_fst[2].text = "0";
                    txt_fst[3].text = "0";
                }
                else
                {
                    txt_fst[0].text = "Lv." + item_num.ToString();
                    txt_fst[1].text = str_clock[item_num];
                    txt_fst[2].text = cost_clock[item_num * 2 + 1].ToString();
                    txt_fst[3].text = cost_clock[item_num * 2].ToString();
                }

                item_num = PlayerPrefs.GetInt("frame", 0);
                if (item_num == 5)
                {
                    txt_sec[0].text = "Lv.MAX";
                    txt_sec[1].text = "품절";
                    txt_sec[2].text = "0";
                    txt_sec[3].text = "0";
                }
                else
                {
                    txt_sec[0].text = "Lv." + item_num.ToString();
                    txt_sec[1].text = str_frame[item_num];
                    txt_sec[2].text = cost_frame[item_num * 2 + 1].ToString();
                    txt_sec[3].text = cost_frame[item_num * 2].ToString();
                }
                break;
            case 1: //액자그림
                shop_fst.GetComponent<Image>().sprite = spr_shops[2];
                shop_sec.GetComponent<Image>().sprite = spr_shops[1];
                item_num = PlayerPrefs.GetInt("frame", 0);
                if (item_num == 5)
                {
                    txt_fst[0].text = "Lv.MAX";
                    txt_fst[1].text = "품절";
                    txt_fst[2].text = "0";
                    txt_fst[3].text = "0";
                }
                else
                {
                    txt_fst[0].text = "Lv." + item_num.ToString();
                    txt_fst[1].text = str_frame[item_num];
                    txt_fst[2].text = cost_frame[item_num * 2 + 1].ToString();
                    txt_fst[3].text = cost_frame[item_num * 2].ToString();
                }
                item_num = PlayerPrefs.GetInt("draw", 0);
                if (item_num == 9)
                {
                    txt_sec[0].text = "Lv.MAX";
                    txt_sec[1].text = "품절";
                    txt_sec[2].text = "0";
                    txt_sec[3].text = "0";
                }
                else
                {
                    txt_sec[0].text = "Lv." + item_num.ToString();
                    txt_sec[1].text = str_draw[item_num];
                    txt_sec[2].text = cost_draw[item_num * 2 + 1].ToString();
                    txt_sec[3].text = cost_draw[item_num * 2].ToString();
                }
                break;
            case 2: //시계그림
                shop_fst.GetComponent<Image>().sprite = spr_shops[0];
                shop_sec.GetComponent<Image>().sprite = spr_shops[1];
                item_num = PlayerPrefs.GetInt("clock", 0);
                if (item_num == 5)
                {
                    txt_fst[0].text = "Lv.MAX";
                    txt_fst[1].text = "품절";
                    txt_fst[2].text = "0";
                    txt_fst[3].text = "0";
                }
                else
                {
                    txt_fst[0].text = "Lv." + item_num.ToString();
                    txt_fst[1].text = str_clock[item_num];
                    txt_fst[2].text = cost_clock[item_num * 2 + 1].ToString();
                    txt_fst[3].text = cost_clock[item_num * 2].ToString();
                }
                item_num = PlayerPrefs.GetInt("draw", 0);
                if (item_num == 9)
                {
                    txt_sec[0].text = "Lv.MAX";
                    txt_sec[1].text = "품절";
                    txt_sec[2].text = "0";
                    txt_sec[3].text = "0";
                }
                else
                {
                    txt_sec[0].text = "Lv." + item_num.ToString();
                    txt_sec[1].text = str_draw[item_num];
                    txt_sec[2].text = cost_draw[item_num * 2 + 1].ToString();
                    txt_sec[3].text = cost_draw[item_num * 2].ToString();
                }
                break;

            default:
                shop_fst.GetComponent<Image>().sprite = spr_shops[0];
                shop_sec.GetComponent<Image>().sprite = spr_shops[1];
                item_num = PlayerPrefs.GetInt("clock", 0);
                if (item_num == 5)
                {
                    txt_fst[0].text = "Lv.MAX";
                    txt_fst[1].text = "품절";
                    txt_fst[2].text = "0";
                    txt_fst[3].text = "0";
                }
                else
                {
                    txt_fst[0].text = "Lv." + item_num.ToString();
                    txt_fst[1].text = str_clock[item_num];
                    txt_fst[2].text = cost_clock[item_num * 2 + 1].ToString();
                    txt_fst[3].text = cost_clock[item_num * 2].ToString();
                }
                item_num = PlayerPrefs.GetInt("draw", 0);
                if (item_num == 9)
                {
                    txt_sec[0].text = "Lv.MAX";
                    txt_sec[1].text = "품절";
                    txt_sec[2].text = "0";
                    txt_sec[3].text = "0";
                }
                else
                {
                    txt_sec[0].text = "Lv." + item_num.ToString();
                    txt_sec[1].text = str_draw[item_num];
                    txt_sec[2].text = cost_draw[item_num * 2 + 1].ToString();
                    txt_sec[3].text = cost_draw[item_num * 2].ToString();
                }
                break;
        }
    }



    public void upFirst()
    {

        have_r = PlayerPrefs.GetInt(str_Code + "r", 0);
        have_h = PlayerPrefs.GetInt(str_Code + "h", 0);

        if (fstBuy == 0)
        {
            switch (shop_rnd)
            {
                case 0: //시계액자
                    item_num = PlayerPrefs.GetInt("clock", 0);
                    if (item_num == 5)
                    {
                    }
                    else if (have_h >= cost_clock[item_num * 2] && have_r >= cost_clock[item_num * 2 + 1])
                    {
                        have_h = have_h - cost_clock[item_num * 2];
                        have_r = have_r - cost_clock[item_num * 2 + 1];
                        item_num++;
                        PlayerPrefs.SetInt(str_Code + "h", have_h);
                        PlayerPrefs.SetInt(str_Code + "r", have_r);
                        PlayerPrefs.SetInt("clock", item_num);
                        txt_fst[0].text = "Lv.X";
                        txt_fst[1].text = "품절";
                        txt_fst[2].text = "X";
                        txt_fst[3].text = "X";
                        fstBuy = 1;
                    }
                    else
                    {
                        popUp_obj.SetActive(true);
                    }
                    break;
                case 1://액자그림
                    item_num = PlayerPrefs.GetInt("frame", 0);
                    if (item_num == 5)
                    {
                    }
                    else if (have_h >= cost_frame[item_num * 2] && have_r >= cost_frame[item_num * 2 + 1])
                    {
                        have_h = have_h - cost_frame[item_num * 2];
                        have_r = have_r - cost_frame[item_num * 2 + 1];
                        item_num++;
                        PlayerPrefs.SetInt(str_Code + "h", have_h);
                        PlayerPrefs.SetInt(str_Code + "r", have_r);
                        PlayerPrefs.SetInt("frame", item_num);
                        txt_fst[0].text = "Lv.X";
                        txt_fst[1].text = "품절";
                        txt_fst[2].text = "X";
                        txt_fst[3].text = "X";
                        fstBuy = 1;
                    }
                    else
                    {
                        popUp_obj.SetActive(true);
                    }
                    break;
                case 2://시계그림
                    item_num = PlayerPrefs.GetInt("clock", 0);
                    if (item_num == 5)
                    {
                    }
                    else if (have_h >= cost_clock[item_num * 2] && have_r >= cost_clock[item_num * 2 + 1])
                    {
                        have_h = have_h - cost_clock[item_num * 2];
                        have_r = have_r - cost_clock[item_num * 2 + 1];
                        item_num++;
                        PlayerPrefs.SetInt(str_Code + "h", have_h);
                        PlayerPrefs.SetInt(str_Code + "r", have_r);
                        PlayerPrefs.SetInt("clock", item_num);
                        txt_fst[0].text = "Lv.X";
                        txt_fst[1].text = "품절";
                        txt_fst[2].text = "X";
                        txt_fst[3].text = "X";
                        fstBuy = 1;
                        if (item_num == 4)
                        {
                        }
                    }
                    else
                    {
                        popUp_obj.SetActive(true);
                    }
                    break;

                default:
                    item_num = PlayerPrefs.GetInt("clock", 0);
                    if (item_num == 5)
                    {
                    }
                    else if (have_h >= cost_clock[item_num * 2] && have_r >= cost_clock[item_num * 2 + 1])
                    {
                        have_h = have_h - cost_clock[item_num * 2];
                        have_r = have_r - cost_clock[item_num * 2 + 1];
                        item_num++;
                        PlayerPrefs.SetInt(str_Code + "h", have_h);
                        PlayerPrefs.SetInt(str_Code + "r", have_r);
                        PlayerPrefs.SetInt("clock", item_num);
                        txt_fst[0].text = "Lv.X";
                        txt_fst[1].text = "품절";
                        txt_fst[2].text = "X";
                        txt_fst[3].text = "X";
                        fstBuy = 1;
                        if (item_num == 4)
                        {
                        }
                    }
                    else
                    {
                        popUp_obj.SetActive(true);
                    }
                    break;
            }
        }

        txt_rain.text = "" + PlayerPrefs.GetInt(str_Code + "r", 0);
        PlayerPrefs.Save();
    }
    public void upSecnd()
    {
        if (secBuy == 0)
        {
            switch (shop_rnd)
            {
                case 0: //시계액자
                    item_num = PlayerPrefs.GetInt("frame", 0);
                    if (item_num == 5)
                    {
                    }
                    else if (have_h >= cost_frame[item_num * 2] && have_r >= cost_frame[item_num * 2 + 1])
                    {
                        have_h = have_h - cost_frame[item_num * 2];
                        have_r = have_r - cost_frame[item_num * 2 + 1];
                        item_num++;
                        PlayerPrefs.SetInt(str_Code + "h", have_h);
                        PlayerPrefs.SetInt(str_Code + "r", have_r);
                        PlayerPrefs.SetInt("frame", item_num);
                        txt_sec[0].text = "Lv.X";
                        txt_sec[1].text = "품절";
                        txt_sec[2].text = "X";
                        txt_sec[3].text = "X";
                        secBuy = 1;
                    }
                    else
                    {
                        popUp_obj.SetActive(true);
                    }
                    break;
                case 1://액자그림
                    item_num = PlayerPrefs.GetInt("draw", 0);
                    if (item_num == 9)
                    {
                    }
                    else if (have_h >= cost_draw[item_num * 2] && have_r >= cost_draw[item_num * 2 + 1])
                    {
                        have_h = have_h - cost_draw[item_num * 2];
                        have_r = have_r - cost_draw[item_num * 2 + 1];
                        item_num++;
                        PlayerPrefs.SetInt(str_Code + "h", have_h);
                        PlayerPrefs.SetInt(str_Code + "r", have_r);
                        PlayerPrefs.SetInt("draw", item_num);
                        txt_sec[0].text = "Lv.X";
                        txt_sec[1].text = "품절";
                        txt_sec[2].text = "X";
                        txt_sec[3].text = "X";
                        secBuy = 1;
                    }
                    else
                    {
                        popUp_obj.SetActive(true);
                    }
                    break;
                case 2://시계그림
                    item_num = PlayerPrefs.GetInt("draw", 0);
                    if (item_num == 9)
                    {
                    }
                    else if (have_h >= cost_draw[item_num * 2] && have_r >= cost_draw[item_num * 2 + 1])
                    {
                        have_h = have_h - cost_draw[item_num * 2];
                        have_r = have_r - cost_draw[item_num * 2 + 1];
                        item_num++;
                        PlayerPrefs.SetInt(str_Code + "h", have_h);
                        PlayerPrefs.SetInt(str_Code + "r", have_r);
                        PlayerPrefs.SetInt("draw", item_num);
                        txt_sec[0].text = "Lv.X";
                        txt_sec[1].text = "품절";
                        txt_sec[2].text = "X";
                        txt_sec[3].text = "X";
                        secBuy = 1;
                    }
                    else
                    {
                        popUp_obj.SetActive(true);
                    }
                    break;

                default:
                    item_num = PlayerPrefs.GetInt("draw", 0);
                    if (item_num == 9)
                    {
                    }
                    else if (have_h >= cost_draw[item_num * 2] && have_r >= cost_draw[item_num * 2 + 1])
                    {
                        have_h = have_h - cost_draw[item_num * 2];
                        have_r = have_r - cost_draw[item_num * 2 + 1];
                        item_num++;
                        PlayerPrefs.SetInt(str_Code + "h", have_h);
                        PlayerPrefs.SetInt(str_Code + "r", have_r);
                        PlayerPrefs.SetInt("draw", item_num);
                        txt_sec[0].text = "Lv.X";
                        txt_sec[1].text = "품절";
                        txt_sec[2].text = "X";
                        txt_sec[3].text = "X";
                        secBuy = 1;
                    }
                    else
                    {
                        popUp_obj.SetActive(true);
                    }
                    break;
            }
        }

        txt_rain.text = "" + PlayerPrefs.GetInt(str_Code + "r", 0);
        PlayerPrefs.Save();
    }
}
