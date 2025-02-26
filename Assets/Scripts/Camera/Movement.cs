using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 move;
    public float speed;
    public float jump;
    public Transform orientation;
    public LayerMask Ground;

    private float vertical;
    private float horizontal;

    public float downwardForce;
    public float downwardMultiplier;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
      
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        move = orientation.right * horizontal + orientation.forward * vertical;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumping();
        }
        if (IsGrounded()){
            downwardForce = 0;
        }
        else{
            downwardForce += Time.deltaTime * downwardMultiplier;
            rb.AddForce(-transform.up * downwardForce, ForceMode.Acceleration);
        
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(move.normalized * speed, ForceMode.Acceleration);
    }

    public void jumping()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        rb.AddForce(transform.up * jump, ForceMode.Impulse);
    }

    public bool IsGrounded()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1.5f, Ground))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
