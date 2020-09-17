using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleChange : MonoBehaviour
{
    public GameObject turtleWin_obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ActTurtle()
    {
        if (turtleWin_obj.activeSelf)
        {
            turtleWin_obj.SetActive(false);
        }
        else
        {
            turtleWin_obj.SetActive(true);
        }
    }

    public void ChangeRH()
    {

    }
    public void ChangeHR()
    {

    }
}
