using UnityEngine;

public class Player_move : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float maxSpeed = 10.0f;
    [SerializeField] private float jumpForce = 10.0f;
    private bool isGrounded;

    public KeyCode Forward_Button = KeyCode.W;
    public KeyCode Left_Button = KeyCode.A;
    public KeyCode Back_Button = KeyCode.S;
    public KeyCode Right_Button = KeyCode.D;
    public KeyCode Jump_Button = KeyCode.Space;

    void Start()
    {
        Physics.IgnoreLayerCollision(0, 2);
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
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.AddForce(-1 * Vector3.ClampMagnitude(rb.linearVelocity, rb.linearVelocity.magnitude - maxSpeed), ForceMode.Impulse);
        }
    }
}