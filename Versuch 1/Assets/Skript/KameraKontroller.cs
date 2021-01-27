using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontroller : MonoBehaviour
{
    public float movementSpeed;
    public float movementTime;

    public Vector3 newPosition;
    public Vector3 newZoom;
    public Vector3 zoomAmount;

    public Transform cameraTransform;

    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;
    public static bool aktiviert=true;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = newPosition;
        newZoom = cameraTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (aktiviert)
        {
            HandleMouseInput();
            HandleMovementInput();
        }

    }

    private void HandleMouseInput()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            newZoom += Input.mouseScrollDelta.y * zoomAmount*10;
        }
        if (Input.GetMouseButtonDown(0))
        {
           dragStartPosition= Utilitys.GetMouseWorldPosition(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
           dragCurrentPosition= Utilitys.GetMouseWorldPosition(Input.mousePosition);
            newPosition = transform.position + dragStartPosition-dragCurrentPosition;
        }
    }

    void HandleMovementInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += (transform.up * movementSpeed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * -movementSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (transform.up * -movementSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * movementSpeed);
        }
        if (Input.GetKey(KeyCode.R))
        {
            newZoom += zoomAmount;
        }
        if (Input.GetKey(KeyCode.F))
        {
            newZoom -= zoomAmount;
        }
        
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);
    }

    
}
