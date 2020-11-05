using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class upgradeButtons : MonoBehaviour, IPointerEnterHandler   //need this for checking if mouse is over
{
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("mouseOver");  
    }
    
}
