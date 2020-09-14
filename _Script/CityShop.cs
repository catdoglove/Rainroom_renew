using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityShop : MonoBehaviour
{
    public GameObject shop_obj, todayShop_obj, shopHelp_obj, doorOpen_obj, doorClose_obj;


    // Start is called before the first frame update
    void Start()
    {
        
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
}
