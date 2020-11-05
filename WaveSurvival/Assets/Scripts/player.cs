using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //movement
    public float speed = 10.0f;
    public float jumpForce = 10.0f;
    private float moveInput;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask groundLayer;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    public int jumpForce2;
    //animations
    public Animator animator;
    private bool facingRight = true;

    //UI
    public GameObject[] hearts;
    public int health;
    private bool canBeDamaged = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
   
    }
    // Update is called once per frame
    void Update()
    {
        checkHealth();

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, groundLayer);
      
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            animator.SetTrigger("jump");
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
        if(facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
    private IEnumerator invicTimer()
    {
        canBeDamaged = false;
        yield return new WaitForSeconds(1);
        canBeDamaged = true;

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy") && canBeDamaged == true)
        {
            health--;
            StartCoroutine(invicTimer());
        }
    }
    private void checkHealth()
    {
        if (health == 3)
        {
            hearts[2].SetActive(true);
            hearts[1].SetActive(true);
            hearts[0].SetActive(true);
        }
        if (health == 2)
        {
            hearts[2].SetActive(false);
            hearts[1].SetActive(true);
            hearts[0].SetActive(true);
        }
        if (health == 1)
        {
            hearts[2].SetActive(false);
            hearts[1].SetActive(false);
            hearts[0].SetActive(true);
        }
        if (health == 0)
        {
            //gameOver
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("jumpPad"))
        {
            rb.AddForce(Vector3.up * jumpForce2);
            Debug.Log("hi");
        }
    }
}
