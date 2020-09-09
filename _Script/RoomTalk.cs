using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq; //랜덤필

public class RoomTalk : MonoBehaviour
{

    List<Dictionary<string, object>> data_talk, data_item; //csv파일
    int etcNum = 0;
    public Text Text_obj; //선언 및 보여질
    string[] testText_cut; //대사 끊기
    string text_str; //실질적 대사출력

    public GameObject talkbtn, itembtn, talkballoon, closeTB, talkCursor; //대화버튼 및 영역
    bool ihaveitem;

    int[] allArr = new int[6]; //총 호감단계
    int loveLv = 0; //호감도 단계라고 생각하면 됨
    int countTalkNum;//대화횟수

    float speedF = 0.05f;
    int nowArr = 0; //현재 줄
    int[] randArr;//난수 필

    //질문만들기
    string quesStr; //질문용대화
    public Text btnTxt1, btnTxt2; //질문버튼 텍스트
    public GameObject quesBtmArea, quesBack; //질문버튼, 뒤
    int choiceNum; //예스or노

    //아이템 관련- 0책, 1벽지, 2전등, 3창문, 4씨앗, 5그림, 6시계
    int[] itemLv = new int[7]; // 등급
    int itemAllArr; //총 줄수 
    int itemNowArr; //현재 줄

    public GameObject change_turtle, turtle_btn;
    int num_turtle;

    //캐릭터 변환
    public Animator charAni;
    
    

    // Start is called before the first frame update
    void Start()
    {
        data_talk = CSVReader.Read("CSV/talk_room"); //대사 불러오기  
        data_item = CSVReader.Read("CSV/talk_item");

        allArr[0] = 50;
        allArr[1] = 50;
        allArr[2] = 85;
        allArr[3] = 85;
        allArr[4] = 85;
        allArr[5] = 200;

        setCharAni();

    }

    void cleantalk() //대화 초기화
    {
        Text_obj.text = "";
        text_str = "";
    }


    void lovetalk()
    { //호감도에 또는 사물에 따른 대화
        int lol;
        if (loveLv >= 5)
        {
            lol = 5;
        }
        else
        {
            lol = loveLv;
        }
        lineReload();
        
        text_str = "" + data_talk[randArr[nowArr - 1]]["대화" + 1]; //문장넣기 0~9
    }

    void lineReload() // 대화 차례대로 보여주기 및 대화줄 초기화
    {
        int lol;
        if (loveLv >= 5)
        {
            lol = 5;
        }
        else
        {
            lol = loveLv;
        }
        if (nowArr == 0) // 난수 돌리기
        {
            GetRandomInt(allArr[0]); //테스트 0
            nowArr++;
        }
        else if (nowArr < allArr[0]) //대화 차례대로 보이기
        {
            nowArr++;
        }
        else if (nowArr >= allArr[0]) //대화 줄 초기화
        {
            GetRandomInt(allArr[0]);
            nowArr = 0;
            nowArr++;
        }

    }

    public int[] GetRandomInt(int length) //중복없는 난수생성기
    {
        randArr = new int[length];
        bool isSame;

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
    }

    public void talkA() //대사치기
    {
        
        //대화속도
        speedF = PlayerPrefs.GetFloat("talkspeed", 0.05f);
        //Debug.Log(countTalkNum);

        //if (countTalkNum == 0)
        // {
        //Debug.Log("대화횟수마감");
        // }
        // else
        // {
        //Audio_obj.GetComponent<SoundEvt>().talkSound();
        if(PlayerPrefs.GetInt("talk", 5) <= 0)
        {

        }
        else
        {
            int a = PlayerPrefs.GetInt("likepoint",0);
            a = a + 10;
            PlayerPrefs.SetInt("likepoint", a);
            lovetalk();
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
        }
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

        charAni.Play("char_talk");
        
        talkballoon.SetActive(true);
        closeTB.GetComponent<Button>().interactable = false;
        closeTB.SetActive(true);

        turtle_btn.SetActive(false);
        talkbtn.SetActive(false);
        quesBtmArea.SetActive(false);
        quesBack.SetActive(false);
        talkCursor.SetActive(false);

    }


    void trueObject()
    {
        closeTB.GetComponent<Button>().interactable = true;
        talkbtn.SetActive(true);
        talkCursor.SetActive(true);
        turtle_btn.SetActive(true);

        setCharAni();

    }


    public void closeTalkBoon()
    {
        talkballoon.SetActive(false);
        closeTB.SetActive(false);
        closeTB.GetComponent<Button>().interactable = false;
        change_turtle.SetActive(false);
    }


    void setCharAni()
    {
        switch (PlayerPrefs.GetInt("likelv", 0))
        {
            case 0:
                charAni.Play("char_ani");
                break;

            case 1:
                charAni.Play("char_ani1");
                break;

            case 2:
                charAni.Play("char_ani2");
                break;

            case 3:
                charAni.Play("char_ani3");
                break;

            case 4:
                charAni.Play("char_ani4");
                break;

            case 5:
                charAni.Play("char_ani5");
                break;

            case 6:
                charAni.Play("char_ani6");
                break;

        }

    }

    void callTalkItem()
    {
       // itemLv[5] = PlayerPrefs.GetInt("그림", 0);
      //  itemLv[6] = PlayerPrefs.GetInt("시계", 0);
    }
    
    IEnumerator itemTalkRun()
    {
        speedF = PlayerPrefs.GetFloat("talkspeed", 0.05f);
        falseObject();
        for (int i = 0; i < testText_cut.Length; i++)
        {
            text_str = text_str.Insert(text_str.Length, testText_cut[i]);
            Text_obj.text = text_str;
            yield return new WaitForSeconds(speedF);
        }

        trueObject();
    }

    //물건 대사

    public void talkBook()
    {
        text_str = "" + data_item[PlayerPrefs.GetInt("booklv", 0)]["book"];
        testText_cut = text_str.Split('/');
        cleantalk();

        StopCoroutine("itemTalkRun");
        StartCoroutine("itemTalkRun");
    }

    public void talkWall()
    {
        text_str = "" + data_item[PlayerPrefs.GetInt("walllv", 0)]["wall"]; 
        testText_cut = text_str.Split('/');
        cleantalk();

        StopCoroutine("itemTalkRun");
        StartCoroutine("itemTalkRun");
    }

    public void talkLight()
    {
        text_str = "" + data_item[PlayerPrefs.GetInt("lightlv", 0)]["light"];
        testText_cut = text_str.Split('/');
        cleantalk();

        StopCoroutine("itemTalkRun");
        StartCoroutine("itemTalkRun");
    }

    public void talkWindow()
    {
        text_str = "" + data_item[PlayerPrefs.GetInt("windowlv", 0)]["window"];
        testText_cut = text_str.Split('/');
        cleantalk();

        StopCoroutine("itemTalkRun");
        StartCoroutine("itemTalkRun");
    }

    public void talkSeed()
    {
        text_str = "" + data_item[PlayerPrefs.GetInt("seedlv", 0)-1]["seed"];
        testText_cut = text_str.Split('/');
        cleantalk();

        StopCoroutine("itemTalkRun");
        StartCoroutine("itemTalkRun");
    }

    public void talkPicture()
    {
        text_str = "" + data_item[PlayerPrefs.GetInt("draw", 0)-1]["picture"];
        testText_cut = text_str.Split('/');
        cleantalk();

        StopCoroutine("itemTalkRun");
        StartCoroutine("itemTalkRun");
    }

    public void talkClock()
    {
        text_str = "" + data_item[PlayerPrefs.GetInt("clock", 0)-1]["clock"];
        testText_cut = text_str.Split('/');
        cleantalk();

        StopCoroutine("itemTalkRun");
        StartCoroutine("itemTalkRun");
    }


    public void talkTurtle()
    {         
        change_turtle.SetActive(true);
        text_str = "" + data_item[num_turtle]["turtle"];
        testText_cut = text_str.Split('/');
        cleantalk();

        StopCoroutine("itemTalkRun");
        StartCoroutine("itemTalkRun");

        if (num_turtle < 9)
        {
            num_turtle++;
        }
        else
        {
            num_turtle = 0;
        }

    }


}
