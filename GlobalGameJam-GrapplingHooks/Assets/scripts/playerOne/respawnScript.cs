using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnScript : MonoBehaviour
{
    public GameObject playerOne;
    public static bool oneIsDead=false;
    public float respawnTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void respawn(){
        StartCoroutine("RespawnCo");


    }
    public IEnumerator RespawnCo()
     {
        playerOne.SetActive(false);
        oneIsDead = true;
        yield return new WaitForSeconds(respawnTime);
        playerOne.transform.position = new Vector2(-5,0);
        playerOne.SetActive(true);
        oneIsDead = false;
     }
}
