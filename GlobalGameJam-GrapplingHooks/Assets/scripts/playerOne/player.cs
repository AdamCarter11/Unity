using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public static bool attacking = false;
    SpriteRenderer m_SpriteRenderer;
    public float forceToAdd = 100;
    private Rigidbody2D rb;
    float timer;
    public int waitingTime;
    public static bool deathOne = false;
    public GameObject camOne;
    public respawnScript respawnScriptVar;
    private int camPos = 1;

    public Transform bulletSpawn;
    public GameObject bulletPref;
    public float bullSpeed;
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
        if(Input.GetKey(KeyCode.A)){
            rb.AddForce(-Vector2.right * forceToAdd);
        }
        if(Input.GetKey(KeyCode.D)){
            rb.AddForce(Vector2.right * forceToAdd);
        }
        if(Input.GetKey(KeyCode.S)){
            Destroy(throwHook.currHook);
            m_SpriteRenderer.color = Color.red;
            attacking = true;
        }
        else{
            m_SpriteRenderer.color = Color.white;
            attacking = false;
        }
        if(transform.position.x > 23 && RespawnTwo.isTwoDead == true){
            
            camOne.transform.position = new Vector3(45,0,-10);
        }
        if(transform.position.x > 68 && RespawnTwo.isTwoDead == true){
            
            //win
        }
        
         if(transform.position.y < -10){
            Destroy(throwHook.currHook);

             respawnScriptVar.respawn();
         }
         if(Input.GetKeyDown(KeyCode.E)){
             GameObject bulletInstance = Instantiate(bulletPref,bulletSpawn.position,bulletSpawn.rotation);
             bulletInstance.GetComponent<Rigidbody2D>().AddForce(transform.forward*bullSpeed);
             //Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(),  GetComponent<Collider2D>());
         }
    }
private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("PlayerTwo") && playerTwo.attackingTwo == true){
        Destroy(throwHook.currHook);

        respawnScriptVar.respawn();        
        }
    }
    
}
