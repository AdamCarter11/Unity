using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwHook : MonoBehaviour
{
    public GameObject hook;
    public static GameObject currHook;
    private bool ropeActive = false;
    public LayerMask collideBoi;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButtonDown(0) )
        if(Input.GetKeyDown(KeyCode.W) && player.attacking == false && player.deathOne == false){
            if(ropeActive == false){

                
                Vector2 angleForHook = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
                //Debug.DrawRay(transform.position, Vector2.up, Color.green, 10f);
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, Mathf.Infinity, collideBoi);
                if (hit.collider != null)
                {
                    currHook = Instantiate(hook, transform.position, Quaternion.identity);
                    currHook.GetComponent<ropesScript>().destiny = hit.point;
                    ropeActive = true;
                }
                
              
            }
            else{
                Destroy(currHook);
                ropeActive = false;
            }
        }
        
    }
}
