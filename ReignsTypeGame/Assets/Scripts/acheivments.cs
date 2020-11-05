using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class acheivments : MonoBehaviour
{
    //general variables
        public GameObject achPanel;
        //public AdioSource achSound; //if I want to make a sound affect - I will also have to add the audio into the game if I wanted it
        public bool achActivte = false;
        public GameObject achTitle;
        public GameObject achDesc;
        public int achDisplayDelay;
    //achievement specfic variables
        //acheivment 1
        public GameObject ach1Image;
        public static int ach1Count = 0;        //static allows variable to be checked between scenes - this could mean we have a seperate scene that shows images of acheivments you have unlocked
        public int ach1Trigger = 1; //basically what is required to get achievment (in this case picking things up)
        public static int ach1Code;

    // Update is called once per frame
    void Update()
    {
        ach1Code = PlayerPrefs.GetInt("ach1");
        if(ach1Count == ach1Trigger && ach1Code != 12345)
        {
            StartCoroutine(Trigger1Ach());
        }
    }

    IEnumerator Trigger1Ach()
    {
        achActivte = true;
        ach1Code = 12345;
        PlayerPrefs.SetInt("ach1", 12345);  //how we can save the data (12345 is just a chosen number, could be anything)
        //achSound.play(); //If I want to play sound
        ach1Image.SetActive(true);
        achTitle.GetComponent<Text>().text = "Ach1 Title";
        achDesc.GetComponent<Text>().text = "Ach1 Description";
        achPanel.SetActive(true);
        
        //displays info for the variables delay
        yield return new WaitForSeconds(achDisplayDelay);
        //then resets UI back
        achPanel.SetActive(false);
        ach1Image.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActivte = false;
    }

}
