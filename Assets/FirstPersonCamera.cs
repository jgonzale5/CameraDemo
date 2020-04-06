using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float turningSpeed = 10f;
    public KeyCode leftTurnKey;
    public KeyCode rightTurnKey;

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRotation = this.transform.eulerAngles;

        if (Input.GetKey(leftTurnKey))
        {
            currentRotation.y -= turningSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(rightTurnKey))
        {
            currentRotation.y += turningSpeed * Time.deltaTime;
        }

        this.transform.eulerAngles = currentRotation;
    }
}
