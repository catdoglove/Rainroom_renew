using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeadalEvt : MonoBehaviour
{
    public GameObject Beadal_obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    //배달창
    public void ActBeadal()
    {
        if (Beadal_obj.activeSelf)
        {
            Beadal_obj.SetActive(false);
        }
        else
        {
            Beadal_obj.SetActive(true);

        }
    }

}
