using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetAchButton : MonoBehaviour
{

    public void resetAch()
    {
        PlayerPrefs.DeleteAll();    //this will make it so it resets the playerpref and it can't be activatedd again until game is reset
    }
}
