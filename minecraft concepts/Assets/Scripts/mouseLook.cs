using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public float mouseSens = 100f;
    public Transform playerBod;
    private float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")*mouseSens *Time.deltaTime;  //default unity inputs
        float mouseY = Input.GetAxis("Mouse Y")*mouseSens*Time.deltaTime;
        xRotation -= mouseY;                                                //minus is cleaner than plus, but either could work
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);                      //how we limit our camera movement to only rotate 180 degress
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);      //howe we roate the camera on the y-axis
        playerBod.Rotate(Vector3.up * mouseX);                              //how we rotate the camera on teh x-axis

    }
}
