using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI : MonoBehaviour
{
    private GameObject player;
    private int direction; // + = right, - = left

    // if distance is set to be larger than 0 in Unity, then enemy won't follow the player unless they're within that radius. If it's kept at 0, the enemy will chase the player from any side of the screen.
    public int distance = 0;

    // how fast the enemy goes
    public float speed = 1;

    void FixedUpdate()
    {
        // find the player through their tag
        player = GameObject.FindGameObjectWithTag("Player");

        // calculate distance between player and enemy
        float calc = Vector3.Distance(player.transform.position, transform.position);
        if (distance == 0 || calc < distance)
        {
            // check if player is left or right of the enemy
            if (player.transform.position.x > transform.position.x)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }
            // if it's too close stop it from moving because then it becomes jittery
            if (Mathf.Abs(player.transform.position.x - transform.position.x) >= 1)
            {
                // move the enemy
                transform.position += Vector3.right * Time.deltaTime * direction * 0.1f * speed;
            }   
        }// if distance

    }
}