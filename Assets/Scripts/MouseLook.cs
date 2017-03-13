using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHor = 9f;
    public float sensitivityVer = 9f;
    public float minimumVert = -45f;
    public float maximumVert = 45f;

    private float _rotationX = 0;
    
	// Use this for initialization
	void Start ()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
        switch(axes)
        {
            case RotationAxes.MouseX:
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
                break;
            case RotationAxes.MouseY:
                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVer;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
                transform.localEulerAngles = new Vector3(_rotationX, transform.localEulerAngles.y, 0);
                break;
            case RotationAxes.MouseXAndY:
                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVer;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
                transform.localEulerAngles = new Vector3(_rotationX, transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityHor, 0);
                break;
        }
		
	}
}
