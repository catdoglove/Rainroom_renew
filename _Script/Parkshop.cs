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
    // Start is called before the first frame update
    void Start()
    {
        
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
}
