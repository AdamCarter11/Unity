using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float xMin = 0f;
    Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 desiredPosition = target.position + offset;
        Vector3 clampedPos = new Vector3(Mathf.Clamp(target.transform.position.x, xMin, float.MaxValue), target.transform.position.y, -10);
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, clampedPos, ref velocity, smoothSpeed*Time.deltaTime);
        transform.position = smoothedPosition;
        

    }
}
