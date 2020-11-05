using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Card : ScriptableObject
{
        public int cardID;
        public string cardName;
        public CardSprite sprite;
        public string leftQuote;
        public string rightQuote;
        public string dialouge;

    //card impact values
    //left
    public int fireLeft;
    public int waterLeft;
    public int groundLeft;
    public int electricLeft;
    public int orderLeft;
    public int chaosLeft;
    //right
    public int fireRight;
    public int waterRight;
    public int groundRight;
    public int electriRight;
    public int orderRight;
    public int chaosRight;

    //float calcFireStat = (float) gameLogic.fireStat/gameLogic.maxValue; //I have to create new variables for each stat
    public void left()
        {
            Debug.Log(cardName + " swiped left");
        gameLogic.fireStat += fireLeft;
        gameLogic.waterStat += waterLeft;
        gameLogic.groundStat += groundLeft;
        gameLogic.electricStat += electricLeft;
        gameLogic.orderStats += orderLeft;
        gameLogic.chaosStats += chaosLeft;

    }
    public void right()
        {
            Debug.Log(cardName + " swiped right");
        gameLogic.fireStat += fireRight;
        gameLogic.waterStat += waterRight;
        gameLogic.groundStat += groundRight;
        gameLogic.electricStat += electriRight;
        gameLogic.orderStats += orderRight;
        gameLogic.chaosStats += chaosRight;
    }
}
