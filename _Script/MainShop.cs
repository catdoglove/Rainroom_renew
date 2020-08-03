using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainShop : MonoBehaviour
{
    //방업그레이드
    public GameObject wall_obj, window_obj, turtle_obj, book_obj, light_obj, seed_obj, sleep_obj, seedBtn_obj, glassBtn_obj, desk_obj, today_obj, sleepBtn_obj;
    public Text txt;
    public Sprite[] spr_wall, spr_window, spr_book, spr_light, spr_seed, spr_sleep, spr_glass, spr_desk;
    public int[] cost_wall, cost_window, cost_book, cost_light;
    public int[] upCk;
    public int item_num;

    public Text[] txt_window, txt_wall, txt_book, txt_light, txt_turtle, txt_seed, txt_sleep, txt_glass;
    public string[] window_name, wall_name, book_name, light_name;
    public Text txt_rain, txt_heart;
    public GameObject shopWin_obj, shopPopup_obj;

    int cost_r, cost_h, level, sum, have_r, have_h;

    string str_Code;

    
    private void Awake()
    {
        first();
    }

    // Start is called before the first frame update
    void Start()
    {
        str_Code = PlayerPrefs.GetString("code", "");
    }



    public void shopAct()
    {
        if (shopWin_obj.activeSelf)
        {
            shopWin_obj.SetActive(false);
        }
        else
        {
            shopWin_obj.SetActive(true);

            txt_rain.text = "" + PlayerPrefs.GetInt(str_Code + "r", 0);
            txt_heart.text = "" + PlayerPrefs.GetInt(str_Code + "h", 0);
            WindowRe();
        }

    }

    void setPrice()
    {
        //물마음-창문
        cost_window[0]=0;
        cost_window[1] = 15;

        cost_window[2] = 60;
        cost_window[3] = 30;

        cost_window[4] = 500;
        cost_window[5] = 100;
        
        cost_window[6] = 1000;
        cost_window[7] = 120;
        
        cost_window[8] = 2000;
        cost_window[9] = 150;

        cost_window[10] = 5000;
        cost_window[11] = 190;

        cost_window[12] = 9000;
        cost_window[13] = 240;

        cost_window[14] = 15000;
        cost_window[15] = 400;

        cost_window[16] = 0;
        cost_window[17] = 0;

        //물마음-벽
        cost_wall[0] = 4000;
        cost_wall[1] = 300;

        cost_wall[2] = 15000;
        cost_wall[3] = 500;

        cost_wall[4] = 0;
        cost_wall[5] = 0;


        //물마음-책
        cost_book[0] = 0;
        cost_book[1] = 10;

        cost_book[2] = 50;
        cost_book[3] = 20;

        cost_book[4] = 300;
        cost_book[5] = 50;

        cost_book[6] = 1000;
        cost_book[7] = 70;

        cost_book[8] = 2000;
        cost_book[9] = 100;

        cost_book[10] = 5000;
        cost_book[11] = 130;

        cost_book[12] = 9000;
        cost_book[13] = 160;

        cost_book[14] = 15000;
        cost_book[15] = 200;

        cost_book[16] = 30000;
        cost_book[17] = 450;
        
        cost_book[16] = 0;
        cost_book[17] = 0;

        //물마음-전등
        cost_light[0] = 10000;
        cost_light[1] = 100;

        cost_light[2] = 15000;
        cost_light[3] = 200;

        cost_wall[4] = 0;
        cost_wall[5] = 0;

    }

    public void buyWindow()
    {
        WindowRe();
        if (level >= 8) { }
        else
        {
            have_r = PlayerPrefs.GetInt(str_Code + "r", 0);
            have_h = PlayerPrefs.GetInt(str_Code + "h", 0);
            if (have_r >= cost_r)
            {
                if (have_h >= cost_h)
                {
                    level++;
                    PlayerPrefs.SetInt("windowlv", level);
                    WindowRe();
                }
                else
                {
                    shopPopup_obj.SetActive(true);
                }
            }
            else
            {
                shopPopup_obj.SetActive(true);
            }
        }
    }
    void WindowRe()
    {
        level = PlayerPrefs.GetInt("windowlv", 0);
        calc();
        //레벨
        txt_window[0].text = "" + level;
        //이름
        txt_window[1].text = "";
        //물
        txt_window[2].text = "" + cost_r;
        //마음
        txt_window[3].text = "" + cost_h;

    }

    void wallRe()
    {
        level = PlayerPrefs.GetInt("walllv", 0);
        calc();
        //레벨
        txt_wall[0].text = "" + level;
        //이름
        txt_wall[1].text = "";
        //물
        txt_wall[2].text = "" + cost_r;
        //마음
        txt_wall[3].text = "" + cost_h;

    }
    void bookRe()
    {
        level = PlayerPrefs.GetInt("booklv", 0);
        calc();
        //레벨
        txt_book[0].text = "" + level;
        //이름
        txt_book[1].text = "";
        //물
        txt_book[2].text = "" + cost_r;
        //마음
        txt_book[3].text = "" + cost_h;

    }

    void lightRe()
    {
        level = PlayerPrefs.GetInt("lightlv", 0);
        calc();
        //레벨
        txt_light[0].text = "" + level;
        //이름
        txt_light[1].text = "";
        //물
        txt_light[2].text = "" + cost_r;
        //마음
        txt_light[3].text = "" + cost_h;
    }

    void calc()
    {
        sum = level * 2;
        cost_r = cost_window[sum];
        cost_h = cost_window[sum + 1];
        PlayerPrefs.SetInt(str_Code + "r", have_r - cost_r);
        PlayerPrefs.SetInt(str_Code + "h", have_h - cost_h);
        txt_rain.text = "" + PlayerPrefs.GetInt(str_Code + "r", 0);
        txt_heart.text = "" + PlayerPrefs.GetInt(str_Code + "h", 0);
    }

    public void closePop()
    {
        shopPopup_obj.SetActive(false);
    }

    void first()
    {
        #region
        int c = 0;
        string str = "";
        if (c == PlayerPrefs.GetInt("first", 0))
        {
            for (int i = 0; i < 16; i++)
            {
                int a = Random.Range(0, 16);//0~15
                switch (a)
                {
                    case 0:
                        str = str + "0";
                        break;
                    case 1:
                        str = str + "1";
                        break;
                    case 2:
                        str = str + "2";
                        break;
                    case 3:
                        str = str + "3";
                        break;
                    case 4:
                        str = str + "4";
                        break;
                    case 5:
                        str = str + "5";
                        break;
                    case 6:
                        str = str + "6";
                        break;
                    case 7:
                        str = str + "7";
                        break;
                    case 8:
                        str = str + "8";
                        break;
                    case 9:
                        str = str + "9";
                        break;
                    case 10:
                        str = str + "a";
                        break;
                    case 11:
                        str = str + "b";
                        break;
                    case 12:
                        str = str + "c";
                        break;
                    case 13:
                        str = str + "d";
                        break;
                    case 14:
                        str = str + "e";
                        break;
                    case 15:
                        str = str + "f";
                        break;
                    default:
                        break;
                }
            }

            PlayerPrefs.SetString("code", str);
            PlayerPrefs.SetInt("first", 1);
            PlayerPrefs.Save();
        }//endOfIf

        #endregion
    }


}
