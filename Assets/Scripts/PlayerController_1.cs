using UnityEngine;

public class PlayerController_1 : MonoBehaviour
{   
    public Transform Camera;
    private Vector3 offset = new Vector3(0, 10, 0);
    public bool fst_Person = true;
    private bool temppers = true;
    private float x, y;

    private Rigidbody rb;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float maxSpeed = 7.0f;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private bool freezeRotation = false;

    private bool isGrounded;

    public KeyCode Forward_Button = KeyCode.W;
    public KeyCode Left_Button = KeyCode.A;
    public KeyCode Back_Button = KeyCode.S;
    public KeyCode Right_Button = KeyCode.D;
    public KeyCode Jump_Button = KeyCode.Space;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(0, 2);
    }

    void OnCollisionEnter(Collision collision)
    {
        // isGrounded = collision.gameObject.layer < 7 ? true : false;
        isGrounded = true;
    }

    void Update()
    {   
        if (!freezeRotation) {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }

        if (Input.GetKey(Right_Button)) {
            // transform.position += new Vector3(speed * 1.0f, 0, 0) * Time.deltaTime;
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            // rb.AddForce(Vector3.right * speed);
        }
        if (Input.GetKey(Left_Button)) {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(Forward_Button)) {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(Back_Button)) {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKeyDown(Jump_Button) && isGrounded) {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            isGrounded = false;
        }

        // rb.freezeRotation = freezeRotation;

        if (fst_Person) {
            if (temppers) {
                Camera.eulerAngles = new Vector3(0, 0, 0);
                Cursor.visible = false;
                temppers = false;
            }
            x = 1.2f * Input.GetAxis("Mouse X");
            y = -1.2f * Input.GetAxis("Mouse Y");
            Camera.Rotate(y, x, 0);
            transform.Rotate(0, x, 0);
            offset = new Vector3(0, 2, 0);

        }
        else {
            Camera.eulerAngles = new Vector3(90, 0, 0);
            offset = new Vector3(0, 10, 0);
            temppers = true;
            Cursor.visible = true;
        }
        Camera.position = transform.position + offset;
        Camera.eulerAngles = new Vector3(Camera.eulerAngles.x, Camera.eulerAngles.y, 0);
    }
}