using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerCamera;

    float minClampingValue = -90f;
    float maxClampingValue = 90f;

    float lookYRotation = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRotation = this.transform.eulerAngles;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        currentRotation.y += mouseX * mouseSensitivity * Time.deltaTime;

        this.transform.eulerAngles = currentRotation;


        float yInput = -mouseY * mouseSensitivity * Time.deltaTime;

        lookYRotation += yInput;

        lookYRotation = Mathf.Clamp(lookYRotation, minClampingValue, maxClampingValue);

        playerCamera.localRotation = Quaternion.Euler(lookYRotation, 0, 0);
    }
}
