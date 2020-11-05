using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private float moveInput;
    public float jumpForce = 5.0f;
    private bool isGrounded;
    //public Transform groundCheck; //if I don't want it around my player
    public float checkRadius;
    public LayerMask whatIsGround;
    public int resetJumps;
    private int extraJumps;
    private float targetDest=0;
    public GameObject death,wallL, wallR;
    public Text scoreBox;
    public static int score = 0;

    public static int highScore;
    // Start is called before the first frame update
    void Start()
    {
        extraJumps = resetJumps;
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("IncreaseScore", 0f, 1f);
        LoadPlayer();
    }
    void IncreaseScore()
    {
        score++;
    }
    // Update is called once per frame
    void Update()
    {
        scoreBox.text = "Score: " + score;

        if(transform.position.x > 12)
        {
            transform.position = new Vector2(-11,transform.position.y);
        }
        if (transform.position.x < -12)
        {
            transform.position = new Vector2(11, transform.position.y);
        }
        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        if (isGrounded)
        {
            extraJumps = resetJumps;
        }
        if(transform.position.y > targetDest + 10)
        {
            death.transform.position = new Vector2(death.transform.position.x,transform.position.y - 14);
            wallL.transform.position = new Vector2(wallL.transform.position.x, transform.position.y);
            wallR.transform.position = new Vector2(wallR.transform.position.x, transform.position.y);
            targetDest += 10;
        }

    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("death"))
        {
            if(score >= highScore)
            {
                highScore = score;
            }
            SavePlayer();
            SceneManager.LoadScene("gameOver");
        }
    }
    public void SavePlayer()
    {
        SaveSystem.Save(this);
    }
    public void LoadPlayer()
    {
        playerData data = SaveSystem.LoadPlayer();
        highScore = data.highScore;
    }
}
