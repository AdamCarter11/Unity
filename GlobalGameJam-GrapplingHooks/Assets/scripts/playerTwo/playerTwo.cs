using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTwo : MonoBehaviour
{
    public static bool attackingTwo = false;
    SpriteRenderer m_SpriteRenderer;
    public GameObject camOne;

    public float forceToAdd = 100;
    private Rigidbody2D rb;
    float timer;
    public int waitingTime;
    public static bool deathTwo = false;
    public RespawnTwo respawnScriptVar;
    // Start is called before the first frame update
    void Start()
    {
        
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
            rb.AddForce(-Vector2.right * forceToAdd);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            rb.AddForce(Vector2.right * forceToAdd);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            Destroy(throwHookTwo.currHookTwo);
            m_SpriteRenderer.color = Color.red;
            attackingTwo = true;
        }
        else{
            m_SpriteRenderer.color = Color.white;
            attackingTwo = false;
        }
        if(transform.position.x < -22 && respawnScript.oneIsDead == true){
            
            camOne.transform.position = new Vector3(-45,0,-10);
        }
        if(transform.position.x < -66 && respawnScript.oneIsDead == true){
            
            //win
        }
         if(transform.position.y < -10){
            Destroy(throwHookTwo.currHookTwo);

             respawnScriptVar.respawn();
         }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player") && player.attacking == true){
            Destroy(throwHookTwo.currHookTwo);
            respawnScriptVar.respawn();
        }
    }
}
//move camera by 45