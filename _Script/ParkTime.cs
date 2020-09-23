using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkTime : MonoBehaviour
{
    public static int trashRnd2, leafRnd;
    public float moveX, moveY, moveLX, moveLY;
    public GameObject trash_obj, leaf_obj;

    string str;
    // Start is called before the first frame update
    void Start()
    {

        str = PlayerPrefs.GetString("code", "");
        StartCoroutine("updateSecp");
    }

    IEnumerator updateSecp()
    {
        int a = 0;
        while (a == 0)
        {

            Baquitrash();

            //최대량 제한 빗물 마음
            if (PlayerPrefs.GetInt(str + "r", 0) > 999999)
            {
                PlayerPrefs.SetInt(str + "r", 999999);
            }

            if (PlayerPrefs.GetInt(str + "h", 0) > 99999)
            {
                PlayerPrefs.SetInt(str + "h", 99999);
            }
            PlayerPrefs.Save();
            yield return new WaitForSeconds(1f);
        }
        
    }

    void Baquitrash()
    {
        //쓰레기
        if (trashRnd2 == 1)
        {

            if (moveX == 0 && moveX == 0)
            {
                moveX = Random.Range(-7.1f, 7.1f);
            }

            trash_obj.SetActive(true);
            trash_obj.transform.position = new Vector3(moveX, trash_obj.transform.position.y, trash_obj.transform.position.z);

        }
        else
        {
            trashRnd2 = Random.Range(0, 2);
            moveX = Random.Range(-7.1f, 7.1f);
            trash_obj.SetActive(false);
        }

        //잎
        if (leafRnd == 1)
        {

            if (moveLX == 0 && moveLX == 0)
            {
                moveLX = Random.Range(-7.1f, 7.1f);
            }

            leaf_obj.SetActive(true);
            leaf_obj.transform.position = new Vector3(moveLX, leaf_obj.transform.position.y, leaf_obj.transform.position.z);

        }
        else
        {
            leafRnd = Random.Range(0, 2);
            moveLX = Random.Range(-7.1f, 7.1f);
            leaf_obj.SetActive(false);
        }


    }


}
