using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityTime : MonoBehaviour
{
    public static int trashRnd, trashShow, peopleRnd, peopleShow;
    float moveX, moveY, b_moveX, b_moveY;
    public GameObject trash_obj, peoples_obj;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("updateSec");
        StartCoroutine("MoveP");
    }


    IEnumerator updateSec()
    {
        Baquitrash();
        yield return new WaitForSeconds(1f);
    }

    void Baquitrash()
    {

        //봉투
        if (trashRnd == 1)
        {
            trash_obj.SetActive(true);
            trash_obj.transform.position = new Vector3(moveX, moveY, trash_obj.transform.position.z);

        }
        else
        {
            trashRnd = Random.Range(0, 5);
            moveX = Random.Range(-7.1f, 7.1f);
            moveY = Random.Range(1.1f, 3.9f);
            trash_obj.SetActive(false);
        }


        //사람

        if (peopleShow == 0)
        {
            peopleRnd = 0;
            b_moveX = -14.5f;

            peoples_obj.transform.position = new Vector3(b_moveX, peoples_obj.transform.position.y, peoples_obj.transform.position.z);

            peopleRnd = Random.Range(0, 5);
            if (peopleRnd == 1)
            {
                peopleShow = 1;
                peoples_obj.SetActive(true);
            }
        }
        else
        {
        }

    }

    IEnumerator MoveP()
    {
        int a = 0;
        while (a == 0)
        {
            if (peopleShow == 1)
            {
                b_moveX = peoples_obj.transform.position.x + (0.1f);//(1.5f * Time.deltaTime);
                peoples_obj.transform.position = new Vector3(b_moveX, peoples_obj.transform.position.y, peoples_obj.transform.position.z);
                if (b_moveX > 14)
                {
                    peopleShow = 0;
                }
                if (peopleShow == 0)
                {
                    peopleRnd = 0;
                    b_moveX = -14.5f;
                    peoples_obj.transform.position = new Vector3(b_moveX, peoples_obj.transform.position.y, peoples_obj.transform.position.z);
                }
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
