using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 2.0f;
    public float jumpForce = 2.0f;
    private bool isGrounded;
    public Vector3 jump;

    public KeyCode Forward_Button = KeyCode.W;
    public KeyCode Left_Button = KeyCode.A;
    public KeyCode Back_Button = KeyCode.S;
    public KeyCode Right_Button = KeyCode.D;
    public KeyCode Jump_Button = KeyCode.Space;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(0, 2);
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update()
    {   
        if (Input.GetKey(Right_Button))
        {
            rb.AddForce(Vector3.right * speed);
        }
        if (Input.GetKey(Left_Button))
        {
            rb.AddForce(Vector3.left * speed);
        }
        if (Input.GetKey(Forward_Button))
        {
            rb.AddForce(Vector3.forward * speed);
        }
        if (Input.GetKey(Back_Button))
        {
            rb.AddForce(Vector3.back * speed);
        }
        if(Input.GetKeyDown(Jump_Button) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}