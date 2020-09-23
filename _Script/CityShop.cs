using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityShop : MonoBehaviour
{
    public GameObject shop_obj, todayShop_obj, shopHelp_obj, doorOpen_obj, doorClose_obj;
    public GameObject shopYN_obj, shopTodayYN_obj;
    public int num_i;
    public Text[] txt_bed, txt_desk, txt_light;
    public string[] desk_name, bed_name, light_name;
    public int[] cost_desk, cost_bed, cost_light;
    int sum, level, cost_r, cost_h, have_r, have_h;
    string str_Code;

    public GameObject shopPopup_obj;
    public Text txt_Popup;
    // Start is called before the first frame update
    void Start()
    {

        str_Code = PlayerPrefs.GetString("code", "");
    }

    // Update is called once per frame
    public void openShop()
    {
        shop_obj.SetActive(true);
        doorOpen_obj.SetActive(true);
        doorClose_obj.SetActive(false);
    }


    public void closeShop()
    {
        shop_obj.SetActive(false);
        todayShop_obj.SetActive(false);
        doorClose_obj.SetActive(true);
        doorOpen_obj.SetActive(false);
    }

    public void openTodayShop()
    {
        todayShop_obj.SetActive(true);
    }

    public void openHelp()
    {
        shopHelp_obj.SetActive(true);
    }


    public void closeHelp()
    {
        shopHelp_obj.SetActive(false);
    }

    public void Num0()
    {
        num_i = 0;
    }
    public void Num1()
    {
        num_i = 1;
    }
    public void Num2()
    {
        num_i = 2;
    }
    public void Num3()
    {
        num_i = 3;
    }
    public void Num4()
    {
        num_i = 4;
    }
    public void Num5()
    {
        num_i = 5;
    }
    public void Num6()
    {
        num_i = 6;
    }
    public void Num7()
    {
        num_i = 7;
    }

    public void ShopBuyYN()
    {
        shopYN_obj.SetActive(true);
    }
    public void ShopBuyY()
    {

        switch (num_i)
        {
            case 0:
                BuyBed();
                break;
            case 1:
                BuyDesk();
                break;
            case 2:
                BuyLight();
                break;
            default:
                break;
        }
        shopYN_obj.SetActive(false);
    }
    public void ShopBuyN()
    {
        shopYN_obj.SetActive(false);
    }

    public void ShopTodayBuyYN()
    {
        shopTodayYN_obj.SetActive(true);
    }
    public void ShopTodayBuyY()
    {
        shopTodayYN_obj.SetActive(false);

    }

    void BuyBed()
    {


        sum = level * 2;
        cost_h = cost_light[sum];
        cost_r = cost_light[sum + 1];
        have_r = PlayerPrefs.GetInt(str_Code + "r", 0);
        have_h = PlayerPrefs.GetInt(str_Code + "h", 0);
        if (have_r >= cost_r)
        {
            if (have_h >= cost_h)
            {
                //마음
                txt_bed[0].text = "";
                //빗물
                txt_bed[1].text = "";
                //이름
                txt_bed[2].text = "";
                //레벨
                txt_bed[3].text = "";
            }
            else
            {
                shopPopup_obj.SetActive(true);
                txt_Popup.text = "구입하기에는\n가지고 있는 것이 부족하다.";
            }
        }
        else
        {
            shopPopup_obj.SetActive(true);
            txt_Popup.text = "구입하기에는\n가지고 있는 것이 부족하다.";
        }

    }
    void BuyDesk()
    {

        sum = level * 2;
        cost_h = cost_light[sum];
        cost_r = cost_light[sum + 1];
        have_r = PlayerPrefs.GetInt(str_Code + "r", 0);
        have_h = PlayerPrefs.GetInt(str_Code + "h", 0);
        if (have_r >= cost_r)
        {
            if (have_h >= cost_h)
            {
                //마음
                txt_desk[0].text = "";
                //빗물
                txt_desk[1].text = "";
                //이름
                txt_desk[2].text = "";
                //레벨
                txt_desk[3].text = "";
            }
            else
            {
                shopPopup_obj.SetActive(true);
                txt_Popup.text = "구입하기에는\n가지고 있는 것이 부족하다.";
            }
        }
        else
        {
            shopPopup_obj.SetActive(true);
            txt_Popup.text = "구입하기에는\n가지고 있는 것이 부족하다.";
        }
    }
    void BuyLight()
    {

        sum = level * 2;
        cost_h = cost_light[sum];
        cost_r = cost_light[sum + 1];
        have_r = PlayerPrefs.GetInt(str_Code + "r", 0);
        have_h = PlayerPrefs.GetInt(str_Code + "h", 0);
        if (have_r >= cost_r)
        {
            if (have_h >= cost_h)
            {
                //마음
                txt_light[0].text = "";
                //빗물
                txt_light[1].text = "";
                //이름
                txt_light[2].text = "";
                //레벨
                txt_light[3].text = "";
            }
            else
            {
                shopPopup_obj.SetActive(true);
                txt_Popup.text = "구입하기에는\n가지고 있는 것이 부족하다.";
            }
        }
        else
        {
            shopPopup_obj.SetActive(true);
            txt_Popup.text = "구입하기에는\n가지고 있는 것이 부족하다.";
        }
    }
    public void ShopTodayBuyN()
    {
        shopTodayYN_obj.SetActive(false);
    }

    void setPrice()
    {
        //책상
        desk_name[0] = "책상";
        cost_desk[0] = 220;
        cost_desk[1] = 15000;

        desk_name[1] = "나무책상";
        cost_desk[2] = 260;
        cost_desk[3] = 17000;

        desk_name[2] = "원목책상";
        cost_desk[4] = 300;
        cost_desk[5] = 19000;

        desk_name[3] = "원목책상";
        cost_desk[6] = 0;
        cost_desk[7] = 0;

        //침대
        bed_name[0] = "침대";
        cost_bed[0] = 320;
        cost_bed[1] = 20000;

        bed_name[1] = "나무침대";
        cost_bed[2] = 340;
        cost_bed[3] = 22000;

        bed_name[2] = "오동나무침대";
        cost_bed[4] = 380;
        cost_bed[5] = 25000;

        bed_name[3] = "오동나무침대";
        cost_bed[6] = 0;
        cost_bed[7] = 0;

        //전등
        light_name[0] = "하얀전등";
        cost_light[0] = 250;
        cost_light[1] = 17000;

        light_name[1] = "까만전등";
        cost_light[2] = 280;
        cost_light[3] = 19000;

        light_name[2] = "고급전등";
        cost_light[4] = 330;
        cost_light[5] = 24000;

        light_name[3] = "고급전등";
        cost_light[6] = 0;
        cost_light[7] = 0;
    }
}
