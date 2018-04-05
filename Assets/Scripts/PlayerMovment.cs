using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour {

    public float speed;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    public Gun theGun;

    public Camera mainCamera;

   

    void Update()
    {
        //moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        //moveVelocity = moveInput * speed;

        // Look at mouse
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane GroundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (GroundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            gameObject.transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
        
        
        //
 
    }

}

