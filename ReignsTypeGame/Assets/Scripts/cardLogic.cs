using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardLogic : MonoBehaviour
{
 
    public Card card;
    public bool isMouseOver = false;
    private void OnMouseOver()
    {
        isMouseOver = true;
    }
    private void OnMouseExit()
    {
        isMouseOver = false;
    }

    //for when card is swiped right
    public void induceRight()
    {
       //Debug.Log("right is swiped");
        acheivments.ach1Count++;    //just for testing the achievments
    }

    //for when card is swiped left
    public void induceLeft()
    {
        //Debug.Log("left is swiped");
    }

 
}

public enum CardSprite  //almost like an array
{
   PERSON1,
   PERSON2,
   PERSON3
}