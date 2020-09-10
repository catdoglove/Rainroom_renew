using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq; //랜덤필

public class CityTalk : MonoBehaviour
{
    List<Dictionary<string, object>> data_talk, data_eat; //csv파일
    int etcNum = 0;
    public Text Text_obj; //선언 및 보여질
    string[] testText_cut; //대사 끊기
    string text_str; //실질적 대사출력

    public GameObject talkbtn, talkballoon, closeTB, talkCursor, eatballon; //대화버튼 및 영역
    int ckFood;

    int[] allArr = new int[2];
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
    public Sprite[] chareat;

    public GameObject obj_cafe, obj_bunsik,charEat, obj_cafe_YN, obj_bunsik_YN, obj_bunsik_price;
    public Text txt_cafe_YN, txt_bunsik_YN;



    // Start is called before the first frame update
    void Start()
    {
        data_talk = CSVReader.Read("CSV/talk_out");
        data_eat = CSVReader.Read("CSV/city_eat");

        allArr[0] = 100;//대사
        allArr[1] = 10; //음식

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

            case 10://음식

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
        }

        return null;
    }


    public void talkCity() //대사치기
    {
        if (PlayerPrefs.GetInt("talkcityCK", 0) == 88)
        {
            nowArr = 0;
        }
        PlayerPrefs.SetInt("talkcityCK", 99);
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


    void talkBunsik(string str)
    {
        eatFalseObject();
        if (PlayerPrefs.GetInt("talkcityCK", 0) == 99)
        {
            nowArr = 0;
        }
        PlayerPrefs.SetInt("talkcityCK", 88);
        //대화속도
        speedF = PlayerPrefs.GetFloat("talkspeed", 0.05f);

        //소리
        //Audio_obj.GetComponent<SoundEvt>().talkSound();
        lineReload(1);
        text_str = "" + data_eat[randArr1[nowArr - 1]][str];
        testText_cut = text_str.Split('/'); //끊기
        cleantalk();
        StartCoroutine("talkRun");
        StartCoroutine("eatFood");
    }

    public void talkEat0() //순대
    {
        eatYN();
        txt_bunsik_YN.text = "순대의 가격은 80";
        ckFood = 0;

    }

    public void talkEat1() //떡볶이
    {
        eatYN();
        txt_bunsik_YN.text = "떡볶이 가격은 70";
        ckFood = 1;
    }

    public void talkEat2() //어묵
    {
        eatYN();
        txt_bunsik_YN.text = "어묵의 가격은 50";
        ckFood = 2;
    }

    public void talkEat3() //튀김
    {
        eatYN();
        txt_bunsik_YN.text = "튀김의 가격은 70";
        ckFood = 3;
    }


    void talkCafe(string str)
    {
        eatFalseObject();
        if (PlayerPrefs.GetInt("talkcityCK", 0) == 99)
        {
            nowArr = 0;
        }
        PlayerPrefs.SetInt("talkcityCK", 88);
        //대화속도
        speedF = PlayerPrefs.GetFloat("talkspeed", 0.05f);

        //소리
        //Audio_obj.GetComponent<SoundEvt>().talkSound();

        lineReload(1);
        text_str = "" + data_eat[randArr1[nowArr - 1]][str];
        testText_cut = text_str.Split('/'); //끊기
        cleantalk();
        StartCoroutine("talkRun");
        StartCoroutine("eatFood");
    }





    public void talkEat4() //커피
    {
        txt_cafe_YN.text = "커피";
        ckFood = 4;
        eatYN();
    }

    public void talkEat4_2() //차
    {
        txt_cafe_YN.text = "차";
        ckFood = 44;
        eatYN();
    }

    public void talkEat5() //과일주스
    {
        txt_cafe_YN.text = "과일주스";
        ckFood = 5;
        eatYN();
    }

    public void talkEat6() //아이스크림
    {
        txt_cafe_YN.text = "아이스크림";
        ckFood = 6;
        eatYN();
    }

    public void talkEat7() //빵
    {
        txt_cafe_YN.text = "빵";
        ckFood = 7;
        eatYN();
    }

    public void talkEat8() //쿠키
    {
        txt_cafe_YN.text = "쿠키";
        ckFood = 8;
        eatYN();
    }

    public void talkEat9() //샌드위치
    {
        eatYN();
        txt_cafe_YN.text = "샌드위치";
        ckFood = 9;
    }

    public void talkEat9_10() //마카롱
    {
        txt_cafe_YN.text = "마카롱";
        ckFood = 10;
        eatYN();
    }

    //대사 출력
    IEnumerator talkRun()
    {
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
        charAni.Play("city_char_talk");
        talkballoon.SetActive(true);
        closeTB.GetComponent<Button>().interactable = false;
        closeTB.SetActive(true);

        talkbtn.SetActive(false);
        quesBtmArea.SetActive(false);
        quesBack.SetActive(false);
        talkCursor.SetActive(false);
        
    }


    void trueObject()
    {

        talkCursor.SetActive(true);
        closeTB.GetComponent<Button>().interactable = true;
        talkbtn.SetActive(true);

        if((PlayerPrefs.GetInt("talkcityCK", 0) == 88)){

        }else{
            charAni.Play("city_char");
        }

    }


    public void closeTalkBoon()
    {
        talkballoon.SetActive(false);
        closeTB.SetActive(false);
        closeTB.GetComponent<Button>().interactable = false;
    }



    IEnumerator eatFood()
    {
        charEat.SetActive(true);
        charAni.Play("city_char_eat");

        switch (ckFood)
        {
            case 0: //순대
                charEat.GetComponent<Image>().sprite = chareat[0];
                break;

            case 1: //떡볶이
                charEat.GetComponent<Image>().sprite = chareat[1];
                break;

            case 2: //어묵
                charEat.GetComponent<Image>().sprite = chareat[2];
                break;

            case 3: //튀김
                charEat.GetComponent<Image>().sprite = chareat[3];
                break;

            case 4: //커피와 차
                charEat.GetComponent<Image>().sprite = chareat[4];
                break;

            case 44: //커피와 차
                charEat.GetComponent<Image>().sprite = chareat[4];
                break;

            case 5: //과일주스
                charEat.GetComponent<Image>().sprite = chareat[5];
                break;

            case 6: //아이스크림
                charEat.GetComponent<Image>().sprite = chareat[6];
                break;

            case 7: //빵
                charEat.GetComponent<Image>().sprite = chareat[7];
                break;

            case 8: //쿠키
                charEat.GetComponent<Image>().sprite = chareat[8];
                break;

            case 9: //샌드위치
                charEat.GetComponent<Image>().sprite = chareat[9];
                break;

            case 10: //마카롱
                charEat.GetComponent<Image>().sprite = chareat[10];
                break;


        } 

        yield return new WaitForSeconds(2f);

        charAni.Play("city_char");
        charEat.SetActive(false);
    }

    public void openCafe()
    {
        obj_cafe.SetActive(true);
    }
        
    public void closeYN()
    {
        obj_bunsik_price.SetActive(false);
        obj_bunsik_YN.SetActive(false);
        obj_cafe_YN.SetActive(false);
    }

    public void openBunsik()
    {
        obj_bunsik.SetActive(true);
    }

    public void eatFalseObject()
    {
        obj_cafe.SetActive(false);
        obj_cafe_YN.SetActive(false);
        obj_bunsik.SetActive(false);
        obj_bunsik_YN.SetActive(false);
        obj_bunsik_price.SetActive(false);
    }
    
    void eatYN() //이걸로 할까창
    {
            obj_cafe_YN.SetActive(true);
            obj_bunsik_price.SetActive(true);
            obj_bunsik_YN.SetActive(true);
    }

    public void eatYES() 
    {
        switch (ckFood)
        {
            case 0: //순대
                talkBunsik("순대");
                break;

            case 1: //떡볶이
                talkBunsik("떡볶이");
                break;

            case 2: //어묵
                talkBunsik("어묵");
                break;

            case 3: //튀김
                talkBunsik("튀김");
                break;

            case 4: //커피와 차
                talkCafe("커피");
                break;

            case 44: //커피와 차
                talkCafe("차차");
                break;

            case 5: //과일주스
                talkCafe("과일");
                break;

            case 6: //아이스크림
                talkCafe("아이스");
                break;

            case 7: //빵
                talkCafe("빠앙");
                break;

            case 8: //쿠키
                talkCafe("쿠키");
                break;

            case 9: //샌드위치
                talkCafe("샌드위치");
                break;

            case 10: //마카롱
                talkCafe("마카롱");
                break;
        }
    }

}
