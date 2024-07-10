using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private Rigidbody rb;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float maxSpeed = 3.0f;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private bool freezeRotation = true;
    // [SerializeField] private bool freezeRotationX, freezeRotationY, freezeRotationZ;

    private float rotatex, rotatey, rotatez;
    private bool isGrounded;
    private Transform rotating;

    public KeyCode Forward_Button = KeyCode.W;
    public KeyCode Left_Button = KeyCode.A;
    public KeyCode Back_Button = KeyCode.S;
    public KeyCode Right_Button = KeyCode.D;
    public KeyCode Jump_Button = KeyCode.Space;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(0, 2);
        rotating = transform;
    }

    void OnCollisionEnter(Collision collision)
    {
        // isGrounded = collision.gameObject.layer < 7 ? true : false;
        isGrounded = true;
    }

    void Update()
    {   
        if (Input.GetKey(Right_Button)) {
            rb.AddForce(Vector3.right * speed);
        }
        if (Input.GetKey(Left_Button)) {
            rb.AddForce(Vector3.left * speed);
        }
        if (Input.GetKey(Forward_Button)) {
            rb.AddForce(Vector3.forward * speed);
        }
        if (Input.GetKey(Back_Button)) {
            rb.AddForce(Vector3.back * speed);
        }
        if(Input.GetKeyDown(Jump_Button) && isGrounded) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        rb.freezeRotation = freezeRotation;

        // rotatex = freezeRotationX ? 0 : rotating.eulerAngles.x;
        // rotatey = freezeRotationY ? 0 : rotating.eulerAngles.y;
        // rotatez = freezeRotationZ ? 0 : rotating.eulerAngles.z;
        // rotating.eulerAngles = new Vector3 (rotatex, rotatey, rotatez);
    }
}