using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public Rigidbody cameraBody;
    public float speed;
    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Vector3 velocity = Vector3.zero;

   // private PlayerMotor motor;

    Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponentInChildren<Animator>();
        cameraBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        float _xMov = Input.GetAxisRaw("Horizontal");
        float _yMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.up * _yMov;

        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        Move(_velocity);

        /////
        //moveInput = new Vector3(Input.GetAxisRaw("Horizontal") * speed, 0f, Input.GetAxisRaw("Vertical") * speed);
        //moveVelocity = moveInput;
        //moveVelocity.y = cameraBody.velocity.y;
        //cameraBody.velocity = moveInput;

    }

    private void FixedUpdate()
    {
        //cameraBody.velocity = moveVelocity;
        PrefromMovement();
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    } 

    void PrefromMovement()
    {
        if(velocity != Vector3.zero)
        {
            cameraBody.MovePosition(cameraBody.position + velocity * Time.fixedDeltaTime);


        }


        float AniSpeed = 1 * velocity.magnitude;
        animator.SetFloat("speedPercent", AniSpeed);
    }

}
