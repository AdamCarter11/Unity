using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gameLogic : MonoBehaviour
{
    public float fMoveSpeed;
    public cardLogic cl;
    public GameObject card;
    public float fSideMargin;   //used for saying how far we have to swipe
    public float fSideTrigger;
    private float alphaText;
    SpriteRenderer sr;
    public TMP_Text dialogue;
    public TMP_Text characterQuestion;
    public CardArray cardArray;

    private string leftQuote, rightQuote;
    public Card currentCard;
    public Card testCard;
    private bool switchCardChecker;

    //stats
    public static int maxValue = 100;
    public static int minValue = 0;
    public static int fireStat = 50;
    public static int waterStat = 50;
    public static int groundStat = 50;
    public static int electricStat = 50;
    public static int orderStats = 50;
    public static int chaosStats = 50;
    void Start()
    {
        sr = card.GetComponent<SpriteRenderer>();
        loadCard(testCard);

        Stats stats = new Stats(10);    //numbers inside here go to stats
    }

    void Update()
    {
        alphaText = Mathf.Min(Mathf.Abs(card.transform.position.x/2), 1);
        if (Input.GetMouseButton(0) && cl.isMouseOver)
        {
            //If I want this to also move up and down, change float pos -> vector2 pos and get rid of the .x at the end. Then set the cards position = to pos; (and get rid of temp)
            float pos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            Vector2 temp = new Vector2(pos, 0);
            card.transform.position = temp;
        }
        if (card.transform.position.x > fSideMargin)
        {
            dialogue.text = rightQuote;
            // dialogue.alpha = Mathf.Min(card.transform.position.x, 1);
            //sr.color = Color.green;
            if (!Input.GetMouseButton(0) && card.transform.position.x > fSideTrigger && switchCardChecker)
            {
                //cl.induceRight();
                currentCard.right();
                newCard();
                switchCardChecker = false;
                acheivments.ach1Count++;    //just for testing the achievments
                card.transform.position = new Vector2(0, 0);
                switchCardChecker = true;

            }
            
        }
        //card swiped left
        else if (card.transform.position.x < -fSideMargin)
        {
            dialogue.text = leftQuote;
            // dialogue.alpha = Mathf.Min(-card.transform.position.x, 1);
            //sr.color = Color.red;
            if (!Input.GetMouseButton(0) && card.transform.position.x < -fSideTrigger && switchCardChecker)
            {
                //cl.induceLeft();
                currentCard.left();
                newCard();
                switchCardChecker = false;
                card.transform.position = new Vector2(0, 0);
                switchCardChecker = true;
            }
      
        }
        else
        {
            card.transform.position = new Vector2(0, 0);
            switchCardChecker = true;

            //card.transform.position = Vector2.MoveTowards(card.transform.position, new Vector2(0, 0), fMoveSpeed);
        }

        //card swiped to right

            /*
            //card in starting position
        else
        {
            sr.color = Color.white;
            switchCardChecker = true;
        }
        */
        dialogue.alpha = alphaText;
    }

    public void loadCard(Card card)
    {
        sr.sprite = cardArray.sprites[(int)card.sprite];
        leftQuote = card.leftQuote;
        rightQuote = card.rightQuote;
        currentCard = card;
        characterQuestion.text = card.dialouge;
    }
    public void newCard()
    {
        int rollDice = Random.Range(0, cardArray.cards.Length);
        loadCard(cardArray.cards[rollDice]);
    }
}
