using System.Numerics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 move;
    public float speed;
    public float jump;
    public Transform orientation;

    private float vertical;
    private float horizontal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        move = orientation.right * horizontal + orientation.forward * vertical;

        if(Input.GetKeyDown(KeyCode.Space)){
            jumping();
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(move.normalized * speed, ForceMode.Acceleration);
    }
    
    public void jumping(){
        rb.AddForce(transform.up * jump, ForceMode.Impulse);
    }
}

