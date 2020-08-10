using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainShop : MonoBehaviour
{
    //방업그레이드
    public GameObject wall_obj, window_obj, turtle_obj, book_obj, light_obj, seed_obj, bed_obj, seedBtn_obj, cupBtn_obj, desk_obj, today_obj, bedBtn_obj;
    public Text txt;
    public Sprite[] spr_wall, spr_window, spr_book, spr_light, spr_seed, spr_sleep, spr_glass, spr_desk;
    public int[] cost_wall, cost_window, cost_book, cost_light;
    public int[] upCk;
    public int item_num;

    public Text[] txt_window, txt_wall, txt_book, txt_light, txt_turtle, txt_seed, txt_bed, txt_cup;
    public string[] window_name, wall_name, book_name, light_name;
    public Text txt_rain, txt_heart;
    public GameObject shopWin_obj, shopPopup_obj;

    int cost_r, cost_h, level, sum, have_r, have_h;

    string str_Code;

    //MAX용
    public GameObject btn_memoBook, btn_memoWindow, btn_memoSeed, btn_memoLight, btn_memoWall, btn_colorWindow, btn_colorWall, btn_colorLight, btn_colorBed, btn_colorBook;
    public GameObject btn_colorClock, btn_colorDraw, btn_colorFrame, btn_colorDesk, btn_memoClock, btn_memoDraw, btn_boxFrame, btn_boxDesk;
    public Sprite[] spr_windowColorImg, spr_wallColorImg, spr_sleepColorImg, spr_bookColorImg, spr_seedColorImg;
    int wincolNum, wallcolNum, lightcolNum, sleepcolNum, bookcolNum, seedcolNum;
    public Text[] txt_memoName;
    public GameObject memoImg;

    //외출
    public GameObject outItem_obj;

    private void Awake()
    {
        First();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        str_Code = PlayerPrefs.GetString("code", "");
        //가격과 이름
        setPrice();
        Setf();
        
    }

    void Setf()
    {

        if (PlayerPrefs.GetInt("turtlelv", 0) == 1)
        {
            //레벨
            txt_turtle[0].text = "Lv.MAX";
            //이름
            txt_turtle[1].text = "거북이";
            //물
            txt_turtle[2].text = "0";
            //마음
            txt_turtle[3].text = "0";
            turtle_obj.SetActive(true);
        }
        if (PlayerPrefs.GetInt("seedlv", 0) == 1)
        {
            //레벨
            txt_seed[0].text = "Lv.MAX";
            //이름
            txt_seed[1].text = "씨앗";
            //물
            txt_seed[2].text = "0";
            //마음
            txt_seed[3].text = "0";
            seed_obj.SetActive(true);
        }
        if (PlayerPrefs.GetInt("bedlv", 0) == 1)
        {
            //레벨
            txt_bed[0].text = "Lv.MAX";
            //이름
            txt_bed[1].text = "이불";
            //물
            txt_bed[2].text = "0";
            //마음
            txt_bed[3].text = "0";
            bed_obj.SetActive(true);
            bedBtn_obj.SetActive(true);
        }
        if (PlayerPrefs.GetInt("cuplv", 0) == 1)
        {
            //레벨
            txt_cup[0].text = "Lv.MAX";
            //이름
            txt_cup[1].text = "물컵";
            //물
            txt_cup[2].text = "0";
            //마음
            txt_cup[3].text = "0";
            cupBtn_obj.SetActive(true);
        }
        level = PlayerPrefs.GetInt("windowlv", 0);
        window_obj.GetComponent<Image>().sprite = spr_window[level];
        level = PlayerPrefs.GetInt("walllv", 0);
        wall_obj.GetComponent<Image>().sprite = spr_wall[level];
        level = PlayerPrefs.GetInt("booklv", 0);
        book_obj.GetComponent<Image>().sprite = spr_book[level];
        level = PlayerPrefs.GetInt("lightlv", 0);
        light_obj.GetComponent<Image>().sprite = spr_light[level];
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
            WallRe();
            BookRe();
            LightRe();
        }
    }

    void setPrice()
    {
        //물마음-창문
        window_name[0] = "깨진창문";
        cost_window[0]=0;
        cost_window[1] = 15;

        window_name[1] = "보수된창문";
        cost_window[2] = 60;
        cost_window[3] = 30;

        window_name[2] = "보수된창문+";
        cost_window[4] = 500;
        cost_window[5] = 100;

        window_name[3] = "창문";
        cost_window[6] = 1000;
        cost_window[7] = 120;

        window_name[4] = "스티커붙이기";
        cost_window[8] = 2000;
        cost_window[9] = 150;

        window_name[5] = "스티커붙이기+";
        cost_window[10] = 5000;
        cost_window[11] = 190;

        window_name[6] = "커튼달린창문";
        cost_window[12] = 9000;
        cost_window[13] = 240;

        window_name[7] = "밝은커튼";
        cost_window[14] = 15000;
        cost_window[15] = 400;

        window_name[8] = "예쁜커튼";
        cost_window[16] = 0;
        cost_window[17] = 0;

        //물마음-벽
        wall_name[0] = "습기찬벽지";
        cost_wall[0] = 4000;
        cost_wall[1] = 300;

        wall_name[1] = "보수된벽지";
        cost_wall[2] = 15000;
        cost_wall[3] = 500;

        wall_name[2] = "깨끗한벽지";
        cost_wall[4] = 0;
        cost_wall[5] = 0;


        //물마음-책
        book_name[0] = "전단지";
        cost_book[0] = 0;
        cost_book[1] = 10;

        book_name[1] = "신문";
        cost_book[2] = 50;
        cost_book[3] = 20;

        book_name[2] = "찢어진 잡지";
        cost_book[4] = 300;
        cost_book[5] = 50;

        book_name[3] = "위인전";
        cost_book[6] = 1000;
        cost_book[7] = 70;

        book_name[4] = "요리책";
        cost_book[8] = 2000;
        cost_book[9] = 100;

        book_name[5] = "동화책";
        cost_book[10] = 5000;
        cost_book[11] = 130;

        book_name[6] = "유머책";
        cost_book[12] = 9000;
        cost_book[13] = 160;

        book_name[7] = "만화책";
        cost_book[14] = 15000;
        cost_book[15] = 200;

        book_name[8] = "소설책";
        cost_book[16] = 30000;
        cost_book[17] = 450;

        book_name[9] = "책장";
        cost_book[18] = 0;
        cost_book[19] = 0;

        //물마음-전등
        light_name[0] = "깨진 전구";
        cost_light[0] = 10000;
        cost_light[1] = 100;

        light_name[1] = "전구";
        cost_light[2] = 15000;
        cost_light[3] = 200;

        light_name[2] = "불켜진 전구";
        cost_light[4] = 0;
        cost_light[5] = 0;
    }

    public void BuyWindow()
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

                    window_obj.GetComponent<Image>().sprite = spr_window[level];
                    PlayerPrefs.Save();
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

    public void BuyWall()
    {
        WallRe();
        if (level >= 2) { }
        else
        {
            have_r = PlayerPrefs.GetInt(str_Code + "r", 0);
            have_h = PlayerPrefs.GetInt(str_Code + "h", 0);
            if (have_r >= cost_r)
            {
                if (have_h >= cost_h)
                {
                    level++;
                    PlayerPrefs.SetInt("walllv", level);
                    WallRe();

                    wall_obj.GetComponent<Image>().sprite = spr_wall[level];
                    PlayerPrefs.Save();
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

    public void BuyBook()
    {
        BookRe();
        if (level >= 9) { }
        else
        {
            have_r = PlayerPrefs.GetInt(str_Code + "r", 0);
            have_h = PlayerPrefs.GetInt(str_Code + "h", 0);
            if (have_r >= cost_r)
            {
                if (have_h >= cost_h)
                {
                    level++;
                    PlayerPrefs.SetInt("booklv", level);
                    BookRe();

                    book_obj.GetComponent<Image>().sprite = spr_book[level];
                    PlayerPrefs.Save();
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

    public void BuyLight()
    {
        LightRe();
        if (level >= 2) { }
        else
        {
            have_r = PlayerPrefs.GetInt(str_Code + "r", 0);
            have_h = PlayerPrefs.GetInt(str_Code + "h", 0);
            if (have_r >= cost_r)
            {
                if (have_h >= cost_h)
                {
                    level++;
                    PlayerPrefs.SetInt("lightlv", level);
                    LightRe();

                    light_obj.GetComponent<Image>().sprite = spr_light[level];
                    PlayerPrefs.Save();
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

    public void BuyTurtle()
    {
        level = PlayerPrefs.GetInt("turtlelv", 0);
        if (level >= 1) { }
        else
        {
            have_r = PlayerPrefs.GetInt(str_Code + "r", 0);
            have_h = PlayerPrefs.GetInt(str_Code + "h", 0);
            cost_r = 8000;
            cost_h = 250;
            if (have_r >= cost_r)
            {
                if (have_h >= cost_h)
                {
                    level++;
                    PlayerPrefs.SetInt("turtlelv", level);
                    calc();
                    //레벨
                    txt_turtle[0].text = "Lv.MAX";
                    //이름
                    txt_turtle[1].text = "거북이";
                    //물
                    txt_turtle[2].text = "0";
                    //마음
                    txt_turtle[3].text = "0";

                    turtle_obj.SetActive(true);
                    PlayerPrefs.Save();
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

    public void BuySeed()
    {
        level = PlayerPrefs.GetInt("seedlv", 0);
        if (level >= 1) { }
        else
        {
            have_r = PlayerPrefs.GetInt(str_Code + "r", 0);
            have_h = PlayerPrefs.GetInt(str_Code + "h", 0);
            cost_r = 2000;
            cost_h = 100;
            if (have_r >= cost_r)
            {
                if (have_h >= cost_h)
                {
                    level++;
                    PlayerPrefs.SetInt("seedlv", level);
                    calc();
                    //레벨
                    txt_seed[0].text = "Lv.MAX";
                    //이름
                    txt_seed[1].text = "씨앗";
                    //물
                    txt_seed[2].text = "0";
                    //마음
                    txt_seed[3].text = "0";
                    seed_obj.SetActive(true);
                    PlayerPrefs.Save();
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
    public void Buybed()
    {
        level = PlayerPrefs.GetInt("bedlv", 0);
        if (level >= 1) { }
        else
        {
            have_r = PlayerPrefs.GetInt(str_Code + "r", 0);
            have_h = PlayerPrefs.GetInt(str_Code + "h", 0);
            cost_r = 19000;
            cost_h = 290;
            if (have_r >= cost_r)
            {
                if (have_h >= cost_h)
                {
                    level++;
                    PlayerPrefs.SetInt("bedlv", level);
                    calc();
                    //레벨
                    txt_bed[0].text = "Lv.MAX";
                    //이름
                    txt_bed[1].text = "이불";
                    //물
                    txt_bed[2].text = "0";
                    //마음
                    txt_bed[3].text = "0";
                    bed_obj.SetActive(true);
                    bedBtn_obj.SetActive(true);
                    PlayerPrefs.Save();
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
    public void BuyCup()
    {
        level = PlayerPrefs.GetInt("cuplv", 0);
        if (level >= 1) { }
        else
        {
            have_r = PlayerPrefs.GetInt(str_Code + "r", 0);
            have_h = PlayerPrefs.GetInt(str_Code + "h", 0);
            cost_r = 2000;
            cost_h = 100;
            if (have_r >= cost_r)
            {
                if (have_h >= cost_h)
                {
                    level++;
                    PlayerPrefs.SetInt("cuplv", level);
                    calc();
                    //레벨
                    txt_cup[0].text = "Lv.MAX";
                    //이름
                    txt_cup[1].text = "물컵";
                    //물
                    txt_cup[2].text = "0";
                    //마음
                    txt_cup[3].text = "0";
                    cupBtn_obj.SetActive(true);
                    PlayerPrefs.Save();
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
        sum = level * 2;
        cost_r = cost_window[sum];
        cost_h = cost_window[sum + 1];
        calc();
        //레벨
        txt_window[0].text = "Lv." + level;
        //이름
        txt_window[1].text = window_name[level];
        //물
        txt_window[2].text = "" + cost_r;
        //마음
        txt_window[3].text = "" + cost_h;

        if (level >= 8)
        {
            txt_window[0].text = "Lv.MAX";
            btn_memoWindow.SetActive(true);
            btn_colorWindow.SetActive(true);

        }
    }

    void WallRe()
    {
        level = PlayerPrefs.GetInt("walllv", 0);
        sum = level * 2;
        cost_r = cost_wall[sum];
        cost_h = cost_wall[sum + 1];
        calc();
        //레벨
        txt_wall[0].text = "Lv." + level;
        //이름
        txt_wall[1].text = wall_name[level];
        //물
        txt_wall[2].text = "" + cost_r;
        //마음
        txt_wall[3].text = "" + cost_h;
        if (level >= 2)
        {
            txt_wall[0].text = "Lv.MAX";
            btn_memoWall.SetActive(true);
            btn_colorWall.SetActive(true);
        }
    }
    void BookRe()
    {
        level = PlayerPrefs.GetInt("booklv", 0);
        sum = level * 2;
        cost_r = cost_book[sum];
        cost_h = cost_book[sum + 1];
        calc();
        //레벨
        txt_book[0].text = "Lv." + level;
        //이름
        txt_book[1].text = book_name[level];
        //물
        txt_book[2].text = "" + cost_r;
        //마음
        txt_book[3].text = "" + cost_h;
        if (level >= 9)
        {
            txt_book[0].text = "Lv.MAX";
            btn_memoBook.SetActive(true);
            btn_colorBook.SetActive(true);
        }
    }

    void LightRe()
    {
        level = PlayerPrefs.GetInt("lightlv", 0);
        sum = level * 2;
        cost_r = cost_light[sum];
        cost_h = cost_light[sum + 1];
        calc();
        //레벨
        txt_light[0].text = "Lv." + level;
        //이름
        txt_light[1].text = light_name[level];
        //물
        txt_light[2].text = "" + cost_r;
        //마음
        txt_light[3].text = "" + cost_h;
        if (level >= 2)
        {
            txt_light[0].text = "Lv.MAX";
            btn_memoLight.SetActive(true);
            btn_colorLight.SetActive(true);
        }
    }

    void calc()
    {
        have_r = have_r - cost_r;
        have_h = have_h - cost_h;
        PlayerPrefs.SetInt(str_Code + "r", have_r);
        PlayerPrefs.SetInt(str_Code + "h", have_h);
        txt_rain.text = "" + PlayerPrefs.GetInt(str_Code + "r", 0);
        txt_heart.text = "" + PlayerPrefs.GetInt(str_Code + "h", 0);
    }

    public void closePop()
    {
        shopPopup_obj.SetActive(false);
    }


    public void ActoutItem()
    {
        if (shopWin_obj.activeSelf)
        {
            outItem_obj.SetActive(false);
        }
        else
        {
            outItem_obj.SetActive(true);

            btn_colorClock.SetActive(true);
            btn_colorDraw.SetActive(true);
            btn_colorFrame.SetActive(true);
            btn_colorDesk.SetActive(true);
            btn_memoClock.SetActive(true);
            btn_memoDraw.SetActive(true);
            btn_boxFrame.SetActive(true);
            btn_boxDesk.SetActive(true);
        }
    }




    public void showBookAllTxt()
    {
        memoImg.SetActive(true);
        txt_memoName[0].text = "책에 대하여";
        memoFalse();
        txt_memoName[1].gameObject.SetActive(true);
    }

    public void showWindowAllTxt()
    {
        memoImg.SetActive(true);
        txt_memoName[0].text = "창문에 대하여";
        memoFalse();
        txt_memoName[2].gameObject.SetActive(true);
    }

    public void showSeedAllTxt()
    {
        memoImg.SetActive(true);
        txt_memoName[0].text = "씨앗에 대하여";
        memoFalse();
        txt_memoName[3].gameObject.SetActive(true);
    }

    public void showLightAllTxt()
    {
        memoImg.SetActive(true);
        txt_memoName[0].text = "전등에 대하여";
        memoFalse();
        txt_memoName[4].gameObject.SetActive(true);
        memoImg.SetActive(true);

    }

    public void showWallAllTxt()
    {
        memoImg.SetActive(true);
        txt_memoName[0].text = "벽지에 대하여";
        memoFalse();
        txt_memoName[5].gameObject.SetActive(true);

    }
    public void showClockAllTxt()
    {
        memoImg.SetActive(true);
        txt_memoName[0].text = "시계에 대하여";
        memoFalse();
        txt_memoName[6].gameObject.SetActive(true);
    }

    public void showPictureAllTxt()
    {
        memoImg.SetActive(true);
        txt_memoName[0].text = "그림에 대하여";
        memoFalse();
        txt_memoName[7].gameObject.SetActive(true);
    }


    public void closeMemo()
    {
        memoImg.SetActive(false);
    }


    void memoFalse()
    {
        for(int i = 1; i <= 7; i++)
        {
            txt_memoName[i].gameObject.SetActive(false);
        }
        memoImg.SetActive(true);
    }



    public void changeWindowColor()
    {
        if (wincolNum < 9)
        { //10개
            wincolNum = PlayerPrefs.GetInt("windowColor", 0) + 1;
            window_obj.GetComponent<Image>().sprite = spr_windowColorImg[wincolNum];
            PlayerPrefs.SetInt("windowColor", wincolNum);
        }
        else
        {
            wincolNum = 0;
            window_obj.GetComponent<Image>().sprite = spr_windowColorImg[wincolNum];
            PlayerPrefs.SetInt("windowColor", 0);
        }
        PlayerPrefs.Save();
    }


    public void changeRoomColor()
    {
        if (wallcolNum < 3)
        { //4개
            wallcolNum = PlayerPrefs.GetInt("wallColor", 0) + 1;
            wall_obj.GetComponent<Image>().sprite = spr_wallColorImg[wallcolNum];
            PlayerPrefs.SetInt("wallColor", wallcolNum);
        }
        else
        {
            wallcolNum = 0;
            wall_obj.GetComponent<Image>().sprite = spr_wallColorImg[wallcolNum];
            PlayerPrefs.SetInt("wallColor", 0);
        }
        PlayerPrefs.Save();
    }


    public void changeLightColor()
    {
        if (lightcolNum < 5)
        { //3~5까지
            lightcolNum = PlayerPrefs.GetInt("lightColor", 3) + 1;
            light_obj.GetComponent<Image>().sprite = spr_light[lightcolNum];
            PlayerPrefs.SetInt("lightColor", lightcolNum);
        }
        else
        {
            lightcolNum = 3;
            light_obj.GetComponent<Image>().sprite = spr_light[lightcolNum];
            PlayerPrefs.SetInt("lightColor", 3);
        }
        PlayerPrefs.Save();
    }


    public void changeBedColor()
    {
        if (sleepcolNum < 4)
        { //5까지
            sleepcolNum = PlayerPrefs.GetInt("sleepColor", 0) + 1;
            bed_obj.GetComponent<Image>().sprite = spr_sleepColorImg[sleepcolNum];
            PlayerPrefs.SetInt("sleepColor", sleepcolNum);
        }
        else
        {
            sleepcolNum = 0;
            bed_obj.GetComponent<Image>().sprite = spr_sleepColorImg[sleepcolNum];
            PlayerPrefs.SetInt("sleepColor", 0);
        }
        PlayerPrefs.Save();
    }

    public void changeBookColor()
    {
        if (bookcolNum < 4)
        { //5개
            bookcolNum = PlayerPrefs.GetInt("bookColor", 0) + 1;
            book_obj.GetComponent<Image>().sprite = spr_bookColorImg[bookcolNum];
            PlayerPrefs.SetInt("bookColor", bookcolNum);
        }
        else
        {
            bookcolNum = 0;
            book_obj.GetComponent<Image>().sprite = spr_bookColorImg[bookcolNum];
            PlayerPrefs.SetInt("bookColor", 0);
        }
        PlayerPrefs.Save();
    }


    public void changeSeedColor()
    {
        if (seedcolNum < 4)
        { //5개
            seedcolNum = PlayerPrefs.GetInt("seedColor", 0) + 1;
            seed_obj.GetComponent<Image>().sprite = spr_seedColorImg[seedcolNum];
            PlayerPrefs.SetInt("seedColor", seedcolNum);
        }
        else
        {
            seedcolNum = 0;
            seed_obj.GetComponent<Image>().sprite = spr_seedColorImg[seedcolNum];
            PlayerPrefs.SetInt("seedColor", 0);
        }
        PlayerPrefs.Save();
    }

    /*
    public void changeClockColor()
    {
        if (clockcolNum < 7)
        { 
            clockcolNum = PlayerPrefs.GetInt("clockColors", 0) + 1;
            clockImg.GetComponent<Image>().sprite = spr_clockColorImg[clockcolNum];
            PlayerPrefs.SetInt("clockColors", clockcolNum);
        }
        else
        {
            clockcolNum = 0;
            clockImg.GetComponent<Image>().sprite = spr_clockColorImg[clockcolNum];
            PlayerPrefs.SetInt("clockColors", 0);
        }
        PlayerPrefs.Save();
    }

    public void changeDrawColor()
    {
        if (drawcolNum < 9)
        { 
            drawcolNum = PlayerPrefs.GetInt("drawColors", 0) + 1;
            drawImg.GetComponent<Image>().sprite = spr_draw[drawcolNum];
            PlayerPrefs.SetInt("drawColors", drawcolNum);
        }
        else
        {
            drawcolNum = 1;
            drawImg.GetComponent<Image>().sprite = spr_draw[drawcolNum];
            PlayerPrefs.SetInt("drawColors", 1);
        }
        PlayerPrefs.Save();
    }

    public void changeFrameColor()
    {
        if (framecolNum < 5)
        { 
            framecolNum = PlayerPrefs.GetInt("frameColors", 0) + 1;
            frameImg.GetComponent<Image>().sprite = spr_frameColorImg[framecolNum];
            PlayerPrefs.SetInt("frameColors", framecolNum);
        }
        else
        {
            framecolNum = 0;
            frameImg.GetComponent<Image>().sprite = spr_frameColorImg[framecolNum];
            PlayerPrefs.SetInt("frameColors", 0);
        }
        PlayerPrefs.Save();
    }
    



    public void changeDeskColor()
    {
        if (deskcolNum < 3)
        { 
            deskcolNum = PlayerPrefs.GetInt("deskColors", 0) + 1;
            desk.GetComponent<Image>().sprite = spr_deskColorImg[deskcolNum];
            PlayerPrefs.SetInt("deskColors", deskcolNum);
        }
        else
        {
            deskcolNum = 0;
            desk.GetComponent<Image>().sprite = spr_deskColorImg[deskcolNum];
            PlayerPrefs.SetInt("deskColors", 0);
        }
        PlayerPrefs.Save();
    }
    */

    void First()
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
