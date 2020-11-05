using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    private Vector3 velocity;
    public float gravity = -9.8f;
    public Transform groundCheck;
    public float groundDist = .4f;
    public LayerMask groundLayer;
    private bool iSGrounded;
    private float jumpHeight = 3f;
    private bool wallRunning = false;
    //raycast testing variables
    public Camera camera;
    public float blockSpeed = 5f;

    private bool damageDelay = true;

    void Update()
    {
        if(wallRunning == false)
        {
            gravity = -9.8f;
        }
        else
        {
            gravity = 0f;
        }



        iSGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundLayer);        //Creates a sphere from the groundCheck position and switches isGrounded to true if on ground, false otherewise
        if(iSGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;     //We don't use new vector values as that would be relative to camera grid, not camera position

        controller.Move(move * speed * Time.deltaTime); //time.deltatime makes it frame rate independant (only works in update, not fixedUpdate)
        if(Input.GetButtonDown("Jump") && iSGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight*-2*gravity); //Physics formuale
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity *Time.deltaTime);

        //raycasting test
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.transform.gameObject.layer == LayerMask.NameToLayer("pullable"))
            {
                Transform hitObject = hit.transform;
                float step = blockSpeed * Time.deltaTime;
                hitObject.position = Vector3.MoveTowards(hitObject.transform.position, transform.position, step);
            }
        }
    }
    private IEnumerator DelayDamage()
    {
        damageDelay = false;
        yield return new WaitForSeconds(2f);
        damageDelay = true;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("wallRun"))
        {
            wallRunning = true;
            StartCoroutine(WallWait());
        }
        if (hit.gameObject.CompareTag("Test")&& damageDelay == true)
        {
            Debug.Log("hit the test");
            StartCoroutine(DelayDamage());
        }
    }
    private IEnumerator WallWait()
    {
        yield return new WaitForSeconds(2.0f);
        wallRunning = false;
    }
}
