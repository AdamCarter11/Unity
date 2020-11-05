using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5.0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("death"))
        {
            Destroy(gameObject);
        }
    }
}
