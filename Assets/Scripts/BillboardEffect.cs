using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardEffect : MonoBehaviour
{
    private Camera my_camera;
    void Start()
    {
        my_camera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + my_camera.transform.rotation * Vector3.forward, my_camera.transform.rotation * Vector3.up);
    }
}
