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


    // Start is called before the first frame update
    void Start()
    {
        
    }



}
