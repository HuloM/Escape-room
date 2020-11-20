using System;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float _tilt;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Pause.Active)
            return;
        
        float mouseRotation = Input.GetAxis("Mouse Y");
        _tilt = Mathf.Clamp(_tilt - mouseRotation, -90f, 45f);
        transform.localRotation = Quaternion.Euler(_tilt, 0f, 0f);
    }
}