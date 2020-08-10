using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTime : MonoBehaviour
{
    string str;
    int talk;

    int wepRnd, wepShow, baqueRnd, baqueShow;
    float moveX, moveY, b_moveX, b_moveY;
    public GameObject wep_obj, baques_obj;

    //신문
    System.DateTime lastGudoc, nowGudog;
    int hG, mG;
    public Button btn_gudoc;
    public Text txt_gudoc;
    System.DateTime lastDateGudog;
    System.TimeSpan compareGudog;
    string lastGudog;


    //전단지
    public int lastgd;
    System.DateTime nowPaper;
    int hGp, mGp;
    public Button btn_paper;
    public Text txt_paper;
    System.DateTime lastDatePaper;
    System.TimeSpan comparePaper;
    string lastPaper;
    public Sprite[] spr_paperFood;


    // Start is called before the first frame update
    void Start()
    {
        //업데이트대신쓴다
        str = PlayerPrefs.GetString("code", "");
        StartCoroutine("updateSec");

        talk = PlayerPrefs.GetInt("talk", 5);
    }


    //
    IEnumerator updateSec()
    {
        int a = 0;
        while (a == 0)
        {
            //최대량 제한 빗물 마음
            if (PlayerPrefs.GetInt(str + "r", 0) > 999999)
            {
                PlayerPrefs.SetInt(str + "r", 999999);
            }

            if (PlayerPrefs.GetInt(str + "h", 0) > 99999)
            {
                PlayerPrefs.SetInt(str + "h", 99999);
            }

            BaquiWep();
            PlayerPrefs.Save();
            yield return new WaitForSeconds(1f);
        }
    }


    public void talkBtn()
    {
        talk--;
        if (talk <= 0)
        {
            talk = 0;
        }
        if (talk >= 5)
        {
            talk = 4;
        }
        PlayerPrefs.SetInt("talk", talk);
    }

    void BaquiWep()
    {

        //거미줄
        if (wepRnd == 1)
        {
            if (wepShow == 0)
            {
                moveX = -8f;
                moveY = -8f;
                wepRnd = 0;
            }
            wepShow = 1;
            wep_obj.SetActive (true);
            wep_obj.transform.position = new Vector3(moveX, moveY, wep_obj.transform.position.z);

        }
        else
        {
            wepRnd = Random.Range(0, 5);
            moveX = Random.Range(-7.1f, 7.1f);
            moveY = Random.Range(-4.1f, 4.1f);
            wep_obj.SetActive (false);
        }


        //바퀴벌레
        
        if (baqueShow == 0)
        {
            baqueRnd = 0;
            b_moveX = -14.5f;

            baques_obj.transform.position = new Vector3(b_moveX, b_moveY, baques_obj.transform.position.z);

            baqueRnd = Random.Range(0, 5);
            if (baqueRnd == 1)
            {
                //baqueShow = 1;
            }
        }
        else
        {
            b_moveX = baques_obj.transform.position.x + (0.02f);//(1.5f * Time.deltaTime);
            baques_obj.transform.position = new Vector3(b_moveX, baques_obj.transform.position.y + 0.001f, baques_obj.transform.position.z);
            if (b_moveX > 14)
            {
                baqueShow = 0;
            }
            if (baqueShow == 0)
            {
                baqueRnd = 0;
                b_moveX = -14.5f;
                baques_obj.transform.position = new Vector3(b_moveX, b_moveY, baques_obj.transform.position.z);
            }
        }
        
    }

    void News()
    {

        //신문시간
        nowGudog = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
        lastGudog = PlayerPrefs.GetString("saveGudoc", nowGudog.ToString());
        lastDateGudog = System.DateTime.Parse(lastGudog);
        compareGudog = System.DateTime.Now - lastDateGudog;
        hG = (int)compareGudog.TotalHours;
        mG = (int)compareGudog.TotalMinutes;
        mG = mG - (mG / 60) * 60;
        mG = 59 - mG;
        hG = 11 - hG;
        if (hG < 0)
        {
            btn_gudoc.GetComponent<Button>().interactable = true;
            hG = 0;
            mG = 0;

        }
        else
        {
            btn_gudoc.GetComponent<Button>().interactable = false;
            string stru = string.Format(@"{0:00}" + ":", hG) + string.Format(@"{0:00}", mG);
            txt_gudoc.text = stru;
        }
    }

    void food()
    {

        //시간
        nowPaper = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
        lastPaper = PlayerPrefs.GetString("savePaper", nowPaper.ToString());
        lastDatePaper = System.DateTime.Parse(lastPaper);
        comparePaper = System.DateTime.Now - lastDatePaper;
        hGp = (int)comparePaper.TotalHours;
        mGp = (int)comparePaper.TotalMinutes;
        mGp = mGp - (mGp / 60) * 60;
        mGp = 59 - mGp;
        hGp = 0 - hGp;
        if (hGp < 0)
        {
            btn_paper.GetComponent<Button>().interactable = true;
            hGp = 0;
            mGp = 0;

        }
        else
        {
            btn_paper.GetComponent<Button>().interactable = false;
            string stru = string.Format(@"{0:00}" + ":", hGp) + string.Format(@"{0:00}", mGp);
            txt_paper.text = stru;
        }
    }
}
