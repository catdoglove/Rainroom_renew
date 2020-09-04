﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq; //랜덤필

public class ParkTalk : MonoBehaviour
{
    List<Dictionary<string, object>> data_talk, data_etc; //csv파일
    int etcNum = 0;
    public Text Text_obj; //선언 및 보여질
    string[] testText_cut; //대사 끊기
    string text_str; //실질적 대사출력

    public GameObject talkbtn, talkballoon, talkcatballoon, closeTB, talkCursor, dalgonaballon; //대화버튼 및 영역
    int ckk;

    int[] allArr = new int[3]; 
    int loveLv = 0; //호감도 단계라고 생각하면 됨
    int countTalkNum;//대화횟수

    float speedF = 0.05f;
    int nowArr = 0; //현재 줄
    int[] randArr, randArr1, randArr2;//난수 필

    //질문만들기
    string quesStr; //질문용대화
    public Text btnTxt1, btnTxt2; //질문버튼 텍스트
    public GameObject quesBtmArea, quesBack; //질문버튼, 뒤
    int choiceNum; //예스or노
    
    //캐릭터 변환
    public Animator charAni;



    // Start is called before the first frame update
    void Start()
    {
        data_talk = CSVReader.Read("CSV/talk_out");
        data_etc = CSVReader.Read("CSV/etc_park");

        allArr[0] = 100;//대사
        allArr[1] = 15; //쓰레기
        allArr[2] = 20; //고양이

    }

    void cleantalk() //대화 초기화
    {
        Text_obj.text = "";
        text_str = "";
    }

    
    void lineReload(int code) // 대화 차례대로 보여주기 및 대화줄 초기화
    {
        if (nowArr == 0) // 난수 돌리기
        {
            GetRandomInt(allArr[code]); //테스트 0
            nowArr++;
        }
        else if (nowArr < allArr[code]) //대화 차례대로 보이기
        {
            nowArr++;
        }
        else if (nowArr >= allArr[code]) //대화 줄 초기화
        {
            GetRandomInt(allArr[code]);
            nowArr = 0;
            nowArr++;
        }

    }

    public int[] GetRandomInt(int length) //중복없는 난수생성기
    {
        bool isSame;

        switch (length)
        {
            case 100://대사

                randArr = new int[length];

                for (int i = 0; i < length; ++i)
                {
                    while (true)
                    {
                        randArr[i] = Random.Range(0, length); //0~(line_txt-1)
                        isSame = false;

                        for (int j = 0; j < i; ++j)
                        {
                            if (randArr[j] == randArr[i])
                            {
                                isSame = true;
                                break;
                            }
                        }
                        if (!isSame) break;
                    }
                }
                return randArr;


                break;

            case 15://쓰레기
                
                randArr1 = new int[length];

                for (int i = 0; i < length; ++i)
                {
                    while (true)
                    {
                        randArr1[i] = Random.Range(0, length); //0~(line_txt-1)
                        isSame = false;

                        for (int j = 0; j < i; ++j)
                        {
                            if (randArr1[j] == randArr1[i])
                            {
                                isSame = true;
                                break;
                            }
                        }
                        if (!isSame) break;
                    }
                }
                return randArr1;

                break;

            case 20://고양이


                randArr2 = new int[length];

                for (int i = 0; i < length; ++i)
                {
                    while (true)
                    {
                        randArr2[i] = Random.Range(0, length); //0~(line_txt-1)
                        isSame = false;

                        for (int j = 0; j < i; ++j)
                        {
                            if (randArr2[j] == randArr2[i])
                            {
                                isSame = true;
                                break;
                            }
                        }
                        if (!isSame) break;
                    }
                }
                return randArr2;

                break;
        }

        return null;
    }


    public void talkPark() //대사치기
    {
        if (PlayerPrefs.GetInt("talkparkCK", 0) == 88 || PlayerPrefs.GetInt("talkparkCK", 0) == 77)
        {
            nowArr = 0;
        }
        PlayerPrefs.SetInt("talkparkCK", 99);
        //대화속도
        speedF = PlayerPrefs.GetFloat("talkspeed", 0.05f);
        //Debug.Log(countTalkNum);

        //if (countTalkNum == 0)
        // {
        //Debug.Log("대화횟수마감");
        // }
        // else
        // {

        //소리
        //Audio_obj.GetComponent<SoundEvt>().talkSound();

        lineReload(0);

        text_str = "" + data_talk[randArr[nowArr - 1]]["park"];

        testText_cut = text_str.Split('/'); //끊기
        cleantalk();

        if (testText_cut[0] == "q")
        { //질문이 있는경우
            StartCoroutine("questionTalkRun");
        }
        else
        {
            StartCoroutine("talkRun");
        }
        //  }
    }

    public void talkTrash() //쓰레기대사
    {
        if (PlayerPrefs.GetInt("talkparkCK", 0)== 99 || PlayerPrefs.GetInt("talkparkCK", 0) == 77)
        {
            nowArr = 0;
        }
        PlayerPrefs.SetInt("talkparkCK", 88);
        //대화속도
        speedF = PlayerPrefs.GetFloat("talkspeed", 0.05f);
        
        //소리
        //Audio_obj.GetComponent<SoundEvt>().talkSound();

        lineReload(1);

        text_str = "" + data_etc[randArr1[nowArr - 1]]["trash"];

        testText_cut = text_str.Split('/'); //끊기
        cleantalk();
        StartCoroutine("talkRun");

    }

    public void talkCat() //고양이대사
    {
        if (PlayerPrefs.GetInt("talkparkCK", 0) == 99 || PlayerPrefs.GetInt("talkparkCK", 0) == 88)
        {
            nowArr = 0;
        }
        PlayerPrefs.SetInt("talkparkCK", 77);
        ckk = 99;

        //대화속도
        speedF = PlayerPrefs.GetFloat("talkspeed", 0.05f);
        //소리
        //Audio_obj.GetComponent<SoundEvt>().talkSound();

        lineReload(2);

        text_str = "" + data_etc[randArr2[nowArr - 1]]["cat"];

        testText_cut = text_str.Split('/'); //끊기
        cleantalk();
        StartCoroutine("talkRun");
        
    }

    //고양이 먹이줌
    public void catYes()
    {
        talkcatballoon.SetActive(false);
        talkballoon.SetActive(false);
        quesBack.SetActive(false);
        talkbtn.SetActive(true);
    }
    public void catNo()
    {
        talkcatballoon.SetActive(false);
        talkballoon.SetActive(false);
        quesBack.SetActive(false);
        talkbtn.SetActive(true);
    }



    //대사 출력
    IEnumerator talkRun()
    {
        talkballoon.SetActive(true);
        falseObject();
        for (int i = 0; i < testText_cut.Length; i++)
        {
            text_str = text_str.Insert(text_str.Length, testText_cut[i]);
            Text_obj.text = text_str;
            yield return new WaitForSeconds(speedF);
        }
        trueObject();
    }

    //질문 출력
    IEnumerator questionTalkRun()
    {
        talkballoon.SetActive(true);
        falseObject();
        closeTB.SetActive(false);
        quesBack.SetActive(true);
        quesStr = " ";
        for (int i = 0; i < testText_cut.Length; i++)
        {
            quesStr = quesStr.Insert(quesStr.Length, testText_cut[i]);
        }

        for (int i = 1; i < testText_cut.Length; i++)
        {
            text_str = text_str.Insert(text_str.Length, testText_cut[i]);

            if (text_str.Contains("y"))
            {
                string str, str2;
                str = quesStr.Substring(quesStr.IndexOf("y") + 1, 4);
                btnTxt1.text = str;
                str2 = quesStr.Substring(quesStr.IndexOf("n") + 1, 4);
                btnTxt2.text = str2;
            }
            else
            {
                Text_obj.text = text_str;
                yield return new WaitForSeconds(speedF);
            }
        }
        quesBtmArea.SetActive(true);
    }

    //선택한 질문 출력
    IEnumerator choiceTextRun()
    {
        talkballoon.SetActive(true);
        falseObject();

        quesStr = " ";
        for (int i = 0; i < testText_cut.Length; i++)
        {
            quesStr = quesStr.Insert(quesStr.Length, testText_cut[i]);
        }

        if (choiceNum == 1)
        {
            for (int i = quesStr.IndexOf("+"); i < quesStr.IndexOf("-") - 1; i++)
            {
                text_str = text_str.Insert(text_str.Length, testText_cut[i]);
                Text_obj.text = text_str;
                yield return new WaitForSeconds(speedF);
            }
        }
        else if (choiceNum == 2)
        {
            for (int i = quesStr.IndexOf("*"); i < quesStr.IndexOf("=") - 1; i++)
            {
                text_str = text_str.Insert(text_str.Length, testText_cut[i]);
                Text_obj.text = text_str;
                yield return new WaitForSeconds(speedF);
            }
        }
        trueObject();
    }


    //질문버튼
    public void choiceBtn1()
    {
        cleantalk();
        choiceNum = 1;
        StartCoroutine("choiceTextRun");

    }

    public void choiceBtn2()
    {
        cleantalk();
        choiceNum = 2;
        StartCoroutine("choiceTextRun");

    }



    void falseObject()
    {
        charAni.Play("park_char_talk");
        talkballoon.SetActive(true);
        closeTB.GetComponent<Button>().interactable = false;
        closeTB.SetActive(true);

        talkbtn.SetActive(false);
        quesBtmArea.SetActive(false);
        quesBack.SetActive(false);
        talkCursor.SetActive(false);

        dalgonaClose();

    }


    void trueObject()
    {

        if (ckk == 99) //고양이대사
        {
            talkcatballoon.SetActive(true);
            quesBack.SetActive(true);
            closeTB.SetActive(false);
            ckk = 0;
        }
        else
        {
            talkCursor.SetActive(true);
            closeTB.GetComponent<Button>().interactable = true;
            talkbtn.SetActive(true);
        }

        charAni.Play("park_char");

    }


    public void closeTalkBoon()
    {
        talkballoon.SetActive(false);
        closeTB.SetActive(false);
        closeTB.GetComponent<Button>().interactable = false;
    }


    public void dalgonaOpen()
    {
        dalgonaballon.SetActive(true);
    }

    public void dalgonaClose()
    {
        dalgonaballon.SetActive(false);
    }
    
    public void dalgonaEat()
    {
        dalgonaballon.SetActive(false);
        StartCoroutine("eatDalgona");
    }

    IEnumerator eatDalgona()
    {
        charAni.Play("park_char_eat");
        yield return new WaitForSeconds(3f);
        charAni.Play("park_char");
    }


}