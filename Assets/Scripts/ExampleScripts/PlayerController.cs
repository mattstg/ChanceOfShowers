using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Vector3 moveDir;
    Vector2 mouseDelta;
    public float maxSpeed = 8;
    public float rocketForce = 10;
    public Vector2 rotationSpeed = new Vector2(10, 10);
    public float jumpForce = 35;
    bool jumpPressed;
    public Collider mainCollider;
    bool isGrounded { get { return coliImCollidingWith.Count > 0; } }

    public Transform head;
    public HashSet<Collider> coliImCollidingWith = new HashSet<Collider>();

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    
    private void FixedUpdate()
    {
        rb.AddRelativeForce(moveDir * rocketForce);  //new Vector(0,10,0)
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        rb.angularVelocity = Vector3.up * rotationSpeed.x * mouseDelta.x;

        if (jumpPressed)
            Jump();
    }
    

    void Update()
    {
        moveDir = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical")).normalized;
        mouseDelta = new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));

        head.Rotate(new Vector3(1, 0, 0) * mouseDelta.y * rotationSpeed.y, Space.Self);

        if(!jumpPressed)
            jumpPressed = Input.GetKeyDown(KeyCode.Space);
    }

   

    void Jump()
    {
        jumpPressed = false;
        if(IsGrounded())
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
    }

    bool IsGrounded()
    {

        return Physics.Raycast(mainCollider.bounds.center - mainCollider.bounds.extents + new Vector3(0,.1f,0), -Vector3.up, .105f, LayerMask.GetMask("Ground", "Wall")); 
        //the .1f offset is so that the raycast is slightly above the ground to not pass through it
    }


    //
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
    //    {
    //        coliImCollidingWith.Add(collision.collider);
    //        //isGrounded = true;
    //    }
    //}
    //
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
    //    {
    //        coliImCollidingWith.Remove(collision.collider);
    //        //isGrounded = false;
    //    }
    //}
}


