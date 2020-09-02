using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutItem : MonoBehaviour
{
    public GameObject outGoodsWin_obj,onRoom_obj;
    public GameObject[] goods_obj;
    public GameObject[] check_obj;
    public Sprite[] spr_goodsImg;
    int item_num;
    // Start is called before the first frame update
    void Start()
    {
        int sum = 0;
        for (int i = 0; i < 9; i++)
        {
            if (PlayerPrefs.GetInt("outgoods"+i, 0) == 1)
            {
                goods_obj[i].SetActive(true);
                sum++;
            }
        }
        if (sum >= 1)
        {
            onRoom_obj.SetActive(true);
        }
        int s=PlayerPrefs.GetInt("setoutgoods");
        onRoom_obj.GetComponent<Image>().sprite = spr_goodsImg[s];
    }
    

    public void Actoutgoods()
    {
        if (outGoodsWin_obj.activeSelf)
        {
            outGoodsWin_obj.SetActive(false);
        }
        else
        {
            for (int i = 0; i < 9; i++)
            {
                    check_obj[i].SetActive(false);
            }
            int s = PlayerPrefs.GetInt("setoutgoods");
            check_obj[s].SetActive(true);
            outGoodsWin_obj.SetActive(true);
        }
    }


    public void Set0()
    {
        item_num = 0;
        SetGoods();
    }
    public void Set1()
    {
        item_num = 1;
        SetGoods();
    }
    public void Set2()
    {
        item_num = 2;
        SetGoods();
    }
    public void Set3()
    {
        item_num = 3;
        SetGoods();
    }
    public void Set4()
    {
        item_num = 4;
        SetGoods();
    }
    public void Set5()
    {
        item_num = 5;
        SetGoods();
    }
    public void Set6()
    {
        item_num = 6;
        SetGoods();
    }
    public void Set7()
    {
        item_num = 7;
        SetGoods();
    }

    public void Set8()
    {
        item_num = 8;
        SetGoods();
    }
    void SetGoods()
    {
        PlayerPrefs.SetInt("setoutgoods", item_num);
        for (int i = 0; i < 9; i++)
        {
            check_obj[i].SetActive(false);
        }
        int s = PlayerPrefs.GetInt("setoutgoods");
        check_obj[s].SetActive(true);
        onRoom_obj.GetComponent<Image>().sprite = spr_goodsImg[s];
    }
}
