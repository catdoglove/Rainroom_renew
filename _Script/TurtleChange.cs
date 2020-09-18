using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurtleChange : MonoBehaviour
{
    public GameObject turtleWin_obj, turtleWinYN_obj;
    int i_change, have_r, have_h;
    public Text txt_r,txt_h;

    string str_Code;

    // Start is called before the first frame update
    void Start()
    {
        str_Code = PlayerPrefs.GetString("code", "");
    }

    public void ActTurtle()
    {
        if (turtleWin_obj.activeSelf)
        {
            turtleWin_obj.SetActive(false);
        }
        else
        {

            have_r = PlayerPrefs.GetInt(str_Code + "r", 0);
            have_h = PlayerPrefs.GetInt(str_Code + "h", 0);

            txt_r.text = "" + have_r;
            txt_h.text = "" + have_h;

            turtleWin_obj.SetActive(true);
        }
    }

    public void ChangeRH()
    {
        turtleWinYN_obj.SetActive(true);
        i_change = 1;
    }
    public void ChangeHR()
    {
        turtleWinYN_obj.SetActive(true);
        i_change = 2;
    }

    public void ChangeY()
    {


        have_r = PlayerPrefs.GetInt(str_Code + "r", 0);
        have_h = PlayerPrefs.GetInt(str_Code + "h", 0);
        /*
        if (i_change == 1)
        {//물>하트
            if (have_r >= 2000)
            {
                have_r = upgrade.rain - 2000;
                have_h = upgrade.heart + 10;
                PlayerPrefs.SetInt(str_Code + "r",have_r);
                PlayerPrefs.SetInt(str_Code + "h", have_h);
                changeTxt.text = "교환되었습니다.";
                changeOKBtn.SetActive(true);
            }
            else
            {
                changeTxt.text = "수량이 부족합니다.";
                changeOKBtn.SetActive(true);
            }
        }
        else if (i_change == 2)
        {//하트>물
            if (upgrade.heart >= 20)
            {
                upgrade.heart = upgrade.heart - 20;
                upgrade.rain = upgrade.rain + 1000;
                PlayerPrefs.SetInt("coin", upgrade.heart);
                PlayerPrefs.SetInt("rain", upgrade.rain);
                changeTxt.text = "교환되었습니다.";
                changeOKBtn.SetActive(true);
            }
            else
            {
                changeTxt.text = "수량이 부족합니다.";
                changeOKBtn.SetActive(true);
            }

        }
        */
    }

    public void ChangeN()
    {
        turtleWinYN_obj.SetActive(false);
    }


}
