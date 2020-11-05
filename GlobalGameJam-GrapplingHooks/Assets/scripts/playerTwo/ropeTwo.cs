using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeTwo : MonoBehaviour
{
    public Vector2 destiny;
    public float speed = 1;
    public float distance = 2;
    public GameObject nodePrefab;
    public GameObject player;
    private GameObject lastNode;
    private int vertexCount = 2;
    private List<GameObject> Nodes = new List<GameObject>();
    private bool done = false;
    private LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerTwo");
        lastNode = transform.gameObject;
        Nodes.Add(transform.gameObject);
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destiny, speed);

        if((Vector2)transform.position != destiny){
            if(Vector2.Distance(player.transform.position, lastNode.transform.position)> distance){
                createNode();
            }
        }
        else if(done == false){
            done = true;
            while(Vector2.Distance(player.transform.position, lastNode.transform.position)> distance){
                createNode();
            }
            lastNode.GetComponent<HingeJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();

        }
        RenderLine();
    }
     void RenderLine(){
         lr.SetVertexCount(vertexCount);
         int i;
         for(i = 0; i < Nodes.Count; i++){
             lr.SetPosition(i, Nodes[i].transform.position);
         }
         lr.SetPosition(i, player.transform.position);
    }
    void createNode(){
        Vector2 pos2Create = player.transform.position - lastNode.transform.position;
        pos2Create.Normalize();
        pos2Create*=distance;
        pos2Create+=(Vector2)lastNode.transform.position;

        GameObject tempNode = (GameObject)Instantiate(nodePrefab,pos2Create,Quaternion.identity);
        tempNode.transform.SetParent(transform);
        lastNode.GetComponent<HingeJoint2D>().connectedBody = tempNode.GetComponent<Rigidbody2D>();
        lastNode = tempNode;
        Nodes.Add(lastNode);
        vertexCount++;
    }
}
