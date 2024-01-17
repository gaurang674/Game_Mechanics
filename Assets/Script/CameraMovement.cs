using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float force;
    public float rotatespeed = 5.0f;
    float horizontalAxis;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        horizontalAxis=rotatespeed * Input.GetAxis("Mouse X");
        transform.Rotate(0,horizontalAxis,0);
    }
}
