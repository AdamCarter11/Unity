using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTwo : MonoBehaviour
{
    public GameObject playerTwo;
    public float respawnTime;
    public static bool isTwoDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void respawn(){
        StartCoroutine("RespawnCo");
    }
    public IEnumerator RespawnCo()
     {
        playerTwo.SetActive(false);
        isTwoDead = true;
        yield return new WaitForSeconds(respawnTime);
        playerTwo.transform.position = new Vector2(5,0);
        isTwoDead = true;
        playerTwo.SetActive(true);
     }
    // Update is called once per frame
    void Update()
    {
        
    }
}
