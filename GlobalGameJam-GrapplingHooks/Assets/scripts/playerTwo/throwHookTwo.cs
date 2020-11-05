using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwHookTwo : MonoBehaviour
{
    public GameObject hook;
    public static GameObject currHookTwo;
    private bool ropeActive = false;
    public LayerMask whatCollide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && playerTwo.attackingTwo == false && playerTwo.deathTwo == false){
            if(ropeActive == false){

                
                //Vector2 angleForHook = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
                //Debug.DrawRay(transform.position, Vector2.up, Color.green, 10f);
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, Mathf.Infinity, whatCollide);
                if (hit.collider != null)
                {
                    currHookTwo = Instantiate(hook, transform.position, Quaternion.identity);
                    currHookTwo.GetComponent<ropeTwo>().destiny = hit.point;
                    ropeActive = true;
                }
                
              
            }
            else{
                Destroy(currHookTwo);
                ropeActive = false;
            }
        }
    }
}
