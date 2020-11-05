using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class reset : MonoBehaviour
{
    public Text scoreText, highScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void resetButton()
    {
        player.score = 0;
        SceneManager.LoadScene("SampleScene");
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "score: " + player.score;
        highScore.text = "High Score: " + player.highScore;
    }
}
