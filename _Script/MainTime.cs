using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTime : MonoBehaviour
{
    string str;
    int talk;

    public static int wepRnd, wepShow, baqueRnd, baqueShow;
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
    int i_news;
    public GameObject news_obj;


    int h;
    int r,like;


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

    //물컵
    public GameObject glassBtn;
    public Sprite[] spr_glass;
    public int glassWater,w;


    //전단지
    public GameObject heartpaperImg, btn_heartHelp;
    public GameObject heartpaperEatBtn;
    public GameObject heartpaperChoice;
    public Text heartNotE;

    //거북이
    public GameObject gobok, btn_gobok, img_bless;
    int beuk;

    // Start is called before the first frame update
    void Start()
    {
        //업데이트대신쓴다
        str = PlayerPrefs.GetString("code", "");
        StartCoroutine("updateSec");
        StartCoroutine("MoveB");

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
            glassWater++;
            if (glassWater >= 30)
            {
                cup();
                glassWater = 0;
            }
            BaquiWep();
            News();
            food();
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
            wep_obj.SetActive (true);
            wep_obj.transform.position = new Vector3(moveX, moveY, wep_obj.transform.position.z);

        }
        else
        {
            wepRnd = Random.Range(0, 5);
            moveX = Random.Range(-7.1f, 7.1f);
            moveY = Random.Range(4.1f, 1.1f);
            wep_obj.SetActive (false);
        }


        //바퀴벌레
        
        if (baqueShow == 0)
        {
            baqueRnd = 0;
            b_moveX = -14.5f;

            baques_obj.transform.position = new Vector3(b_moveX, baques_obj.transform.position.y, baques_obj.transform.position.z);

            baqueRnd = Random.Range(0, 5);
            if (baqueRnd == 1)
            {
                baqueShow = 1;
            }
        }
        else
        {
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


    public void gudocOpen()
    {
        news_obj.SetActive(true);
        PlayerPrefs.SetString("saveGudoc", System.DateTime.Now.ToString());
        h = PlayerPrefs.GetInt(str + "h", 0);
        r = PlayerPrefs.GetInt(str + "r", 0);
        h = h + 50;
        r = r + 500;
        PlayerPrefs.SetInt(str + "r", r);
        PlayerPrefs.SetInt(str + "h", h);
    }


    public void gudocClose()
    {
        news_obj.SetActive(false);
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

    
    public void heartpaperY()
    {//먹는다

        
        h = PlayerPrefs.GetInt(str + "h", 0);
        r = PlayerPrefs.GetInt(str + "r", 0);
        like =PlayerPrefs.GetInt("likelv", 0);

        heartpaperEatBtn.SetActive(true);
        heartpaperEatBtn.GetComponent<Image>().sprite = spr_paperFood[PlayerPrefs.GetInt("heartpaper", 0)];
        switch (PlayerPrefs.GetInt("heartpaper", 0))
        {
            case 1: //짜
                if (h >= 50)
                {
                    h = h - 50;
                    like = like + 7;
                    PlayerPrefs.SetInt(str + "h", h);
                    PlayerPrefs.SetInt("likelv", like);
                    PlayerPrefs.SetString("savePaper", System.DateTime.Now.ToString());
                    PlayerPrefs.Save();
                    heartpaperChoice.SetActive(false);
                }
                else
                {
                    heartNotE.text = "마음이 부족하다.";
                    heartpaperEatBtn.SetActive(false);
                    PlayerPrefs.SetInt("heartpapernomoney", 1);
                }
                break;

            case 2: //볶
                if (h >= 50)
                {
                    h = h - 50;
                    like = like + 7;
                    PlayerPrefs.SetInt(str + "h", h);
                    PlayerPrefs.SetInt("likelv", like);
                    PlayerPrefs.SetString("savePaper", System.DateTime.Now.ToString());
                    PlayerPrefs.Save();
                    heartpaperChoice.SetActive(false);
                }
                else
                {
                    heartNotE.text = "마음이 부족하다.";
                    heartpaperEatBtn.SetActive(false);
                    PlayerPrefs.SetInt("heartpapernomoney", 1);
                }
                break;

            case 3: //우
                if (h >= 60)
                {
                    h = h - 60;
                    like = like + 9;
                    PlayerPrefs.SetInt(str + "h", h);
                    PlayerPrefs.SetInt("likelv", like);
                    PlayerPrefs.SetString("savePaper", System.DateTime.Now.ToString());
                    PlayerPrefs.Save();
                    heartpaperChoice.SetActive(false);
                }
                else
                {
                    heartNotE.text = "마음이 부족하다.";
                    heartpaperEatBtn.SetActive(false);
                    PlayerPrefs.SetInt("heartpapernomoney", 1);
                }
                break;

            case 4: //짬
                if (h >= 60)
                {
                    h = h - 60;
                    like = like + 9;
                    PlayerPrefs.SetInt(str + "h", h);
                    PlayerPrefs.SetInt("likelv", like);
                    PlayerPrefs.SetString("savePaper", System.DateTime.Now.ToString());
                    PlayerPrefs.Save();
                    heartpaperChoice.SetActive(false);
                }
                else
                {
                    heartNotE.text = "마음이 부족하다.";
                    heartpaperEatBtn.SetActive(false);
                    PlayerPrefs.SetInt("heartpapernomoney", 1);
                }
                break;
            default:
                break;
        }
    }
    
    public void heartpaperN()
    {//안
        heartpaperChoice.SetActive(false);
    }

    public void food1()
    {//짜장
        PlayerPrefs.SetInt("heartpaper", 1);
    }
    public void food2()
    {//볶음밥
        PlayerPrefs.SetInt("heartpaper", 2);
    }
    public void food3()
    {//짬뽕
        PlayerPrefs.SetInt("heartpaper", 3);
    }
    public void food4()
    {//우동
        PlayerPrefs.SetInt("heartpaper", 4);
    }
    

    void cup()
    {

        //if (PlayerPrefs.GetInt("glass", 0) == 1)
        //{
            w = PlayerPrefs.GetInt("water", 0);
            if (w < 1)
            { //0
                glassBtn.GetComponent<Image>().sprite = spr_glass[0];
            }
            else if (w < 49)
            { //1~249
                glassBtn.GetComponent<Image>().sprite = spr_glass[1];
            }
            else
            { //250
                glassBtn.GetComponent<Image>().sprite = spr_glass[2];
            }
            if(w > 49)
            {
                w = 49;
            }
            PlayerPrefs.SetInt("water", w + 1);
        //}
    }


    public void getGlassWater()
    {
        if (PlayerPrefs.GetInt("glass", 0) == 0)
        {
        }
        else
        {
            int w = PlayerPrefs.GetInt("water", 0) * 5;
            //upgrade.rain = upgrade.rain + w;
            //PlayerPrefs.SetInt("rain", upgrade.rain);
            PlayerPrefs.SetInt("water", 0);
           // btn_glassShow.SetActive(true);
            //txt_glassShow.text = "물을 " + w + "만큼 모았다.";
        }
    }

    void tutle()
    {
        if (PlayerPrefs.GetInt("sleepmotion", 0) == 1)
        {
            //img_bless.SetActive(false);
        }

        if (moveX <= -5)
        {
            beuk = 1;
            gobok.transform.rotation = Quaternion.Euler(0, 180, 0);
            btn_gobok.transform.Rotate(new Vector3(0, 180, 0));
            //btn_giveWater.transform.Rotate(new Vector3 (0,180,0));
            img_bless.transform.Rotate(new Vector3(0, 180, 0));
        }
        else if (moveX >= 6.5)
        {
            beuk = 0;
            gobok.transform.rotation = Quaternion.Euler(0, 0, 0);
            btn_gobok.transform.Rotate(new Vector3(0, -180, 0));
            //btn_giveWater.transform.Rotate(new Vector3 (0,-180,0));
            img_bless.transform.Rotate(new Vector3(0, -180, 0));
        }
        if (beuk == 1)
        {
            moveX = moveX + 0.001f;
        }
        else
        {
            moveX = moveX - 0.001f;
        }
        gobok.transform.position = new Vector3(moveX, moveY, gobok.transform.position.z);
    }



    IEnumerator MoveB()
    {
        int a = 0;
        while (a == 0)
        {
            if (baqueShow == 1)
            {
                b_moveX = baques_obj.transform.position.x + (0.1f);//(1.5f * Time.deltaTime);
                baques_obj.transform.position = new Vector3(b_moveX, baques_obj.transform.position.y, baques_obj.transform.position.z);
                if (b_moveX > 14)
                {
                    baqueShow = 0;
                }
                if (baqueShow == 0)
                {
                    baqueRnd = 0;
                    b_moveX = -14.5f;
                    baques_obj.transform.position = new Vector3(b_moveX, baques_obj.transform.position.y, baques_obj.transform.position.z);
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
