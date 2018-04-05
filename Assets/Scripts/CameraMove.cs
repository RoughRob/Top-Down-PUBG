using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public Rigidbody cameraBody;
    public float speed;
    private Vector3 moveInput;
    private Vector3 moveVelocity;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal") * speed, 0f, Input.GetAxisRaw("Vertical") * speed);
        moveVelocity = moveInput;
        moveVelocity.y = cameraBody.velocity.y;
        cameraBody.velocity = moveInput;
    }

    private void FixedUpdate()
    {
        cameraBody.velocity = moveVelocity;
    }

}
