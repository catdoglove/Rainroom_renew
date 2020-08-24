using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutItem : MonoBehaviour
{
    public GameObject outGoodsWin_obj;
    public GameObject cat_obj,rain_obj,bear_obj,d;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    public void Actoutgoods()
    {
        if (outGoodsWin_obj.activeSelf)
        {
            outGoodsWin_obj.SetActive(false);
        }
        else
        {
            outGoodsWin_obj.SetActive(true);
        }
    }
}
