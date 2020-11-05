using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject spawnObj;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", .1f, .5f);
    }
    void SpawnObject()
    {
        Color newCol = new Color(Random.value, Random.value, Random.value);
        float rando = Random.Range(-11.0f, 11.0f);
        GameObject spawned = Instantiate(spawnObj, new Vector3(rando,transform.position.y,0.0f), Quaternion.identity);
        spawned.transform.localScale = new Vector3(Random.Range(2f, 4f),Random.Range(1.0f,2.5f),0);
        spawned.GetComponent<SpriteRenderer>().color = newCol;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
